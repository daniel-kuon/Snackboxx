using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using Snackboxx.Core;
using ReadScannerCode;
using System.Threading;
using System.Windows.Forms.Integration;
using Snackboxx.DataBaseSchemaUpdates;
using Snackboxx.UserControls;
using Textmail;

namespace Snackboxx
{
    public partial class SnackboxxForm : Form
    {
        private Input _input;
        public static Config Config;
        private Members _members;
        private Security _security;
        private Color _editcolor = Color.Red;
        private ReadIni _ini = null;
        private WriteIni _wrini = null;
        public static string IniFilePath => Environment.CurrentDirectory + "\\option.ini";
        private IniObj _iniObj;
        private DBConnection _dbConn = new DBConnection();
        private string logfilename = "";
        private List<UserRight> _userrights;
        public SnackboxxForm Form;
        public const string DEFAULT_LIMIT = "10.00";
        
        
        public SnackboxxForm()
        {
            InitializeComponent();
        }

        private void Snackboxx_Load(object sender, EventArgs e)
        {
            _iniObj = new IniObj();
            _userrights = new List<UserRight>();
            _wrini = new WriteIni();

            try
            {

                FileInfo fi = new FileInfo(IniFilePath);
                if (!fi.Exists) fi.Create();
                else
                {
                    _ini = new ReadIni(IniFilePath);
                    _iniObj = _ini.GetIni();
                }
                logfilename = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day;
                _iniObj.LogFilename = logfilename;
                if (string.IsNullOrEmpty(_iniObj.ScanLogPath))
                    _iniObj.ScanLogPath = Environment.CurrentDirectory + "\\ScanLog\\";
                Config = new Config(_iniObj, this, _dbConn);
                _dbConn = Config.DBConn;
                tssinfoFOUR.Text = _dbConn.GetState.ToString();
                
                //after correct connection...
                _input = new Input(_iniObj, this, _dbConn, _userrights);                
                
                this.ShowControl(_input);

                new UnknownCodeSchemaUpdater(_dbConn, _input.WriteInfoLog);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                userToolStripMenuItem.Enabled = false;
                inputToolStripMenuItem.Enabled = false;
            }            
        }

        private void Snackboxx_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WriteIni();
            this._input.Close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowControl(UserControl control)
        {
            if (showpanel.Controls.Count > 0)
                showpanel.Controls.Clear();
            control.Width = showpanel.Width;
            control.Height = showpanel.Height;
            showpanel.Controls.Add(control);
        }

        private void ShowControl(System.Windows.Controls.UserControl control)
        {
            var host = new ElementHost() {
                Child = control
            };
            if (showpanel.Controls.Count > 0)
                showpanel.Controls.Clear();
            host.Dock = DockStyle.Fill;
            showpanel.Controls.Add(host);
        }

        private void showpanel_Resize(object sender, EventArgs e)
        {
            if (showpanel.Controls.Count > 0)
            {
                showpanel.Controls[0].Height = showpanel.Height;
                showpanel.Controls[0].Width = showpanel.Width;
            }
        }

        private void inputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowControl(_input);
        }

        private void WriteIni()
        {
            FileInfo fi = new FileInfo(IniFilePath);
            if (!fi.Exists) fi.Create();
            IniObj inputObj = _input.GetIniObj();
            IniObj configObj = Config.GetIniObj();
            //new iniObj
            IniObj iniObj = new IniObj();
            iniObj.Database = configObj.Database;
            iniObj.Server = configObj.Server;
            iniObj.User = configObj.User;
            iniObj.Password = configObj.Password;
            iniObj.GlobalKey = inputObj.GlobalKey;
            iniObj.MaxRtbLines = inputObj.MaxRtbLines;
            iniObj.ScanLogPath = inputObj.ScanLogPath;
            iniObj.ErrorMail = inputObj.ErrorMail;
            _wrini.Write(fi.FullName, iniObj);
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowControl(new WpfControls.Config());
        }

        public void SetNewDBConnection(ref DBConnection dbconn)
        {
            _dbConn = dbconn;
            this.tssinfoFOUR.Text = _dbConn.GetState.ToString();
            this.ReadUserRights();
            
            _input.WriteInfoLog("New Database Connection...");
            _input.SetDBConnection(_dbConn);
            _members.SetNewParams(_dbConn, _userrights);
            
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ReadUserRights();
            _members = new Members(_dbConn, this, _userrights);
            this.ShowControl(_members);
        }

        public void SettssinfoONE(string text)
        {
            tssinfoONE.Text = text;
        }

        private void ReadUserRights()
        {
            _userrights.Clear();
            string query = "Select * from T_UserRights";
            List<Dictionary<string, string>> table = _dbConn.GetResultList(query, null);
            for (int i = 0; i < table.Count; ++i)
            {
                Dictionary<string, string> element = table[i];
                UserRight right = new UserRight();
                right.userRight = element["UserRight"];
                right.userRightID = element["UserRightID"];
                right.allowposten = Convert.ToBoolean(element["AllowPosten"]);
                right.allowtime = Convert.ToBoolean(element["AllowTime"]);
                right.allowconfig = Convert.ToBoolean(element["AllowConfig"]);
                right.allowadmin = Convert.ToBoolean(element["AllowAdministration"]);
                _userrights.Add(right);
            }
        }

        private void securityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ReadUserRights();
            _security = new Security(_dbConn, this, _userrights);
            this.ShowControl(_security);
        }
        public void sendMail(string email,string opensum)
        {
            try
            {
                string body = "Sie haben einen offenen Betrag von " + opensum + " €.\n"
                                    + "Bitte so schnell wie möglich bei Daniel Kuon begleichen! \n\n"
                                    + "Mit freundlichen Grüßen \n"
                                    + "Ihr Snackboxx - Team \n\n\n\n\n\n\n\n\n"
                                    + "Dies ist eine automatisch generierte E-Mail.  \n"
                                    + "Bei Fragen wenden Sie sich bitte an Daniel.Kuon@rohlig.com.";                

                sendmail.send("Snackboxx@rohlig.com", email, "Snackboxx Zahlungsaufforderung ;)", body, "192.168.2.68");
                sendmail.send("Snackboxx@rohlig.com", _iniObj.ErrorMail, "Zahlungsaufforderung fuer '"+ email +"': '"+opensum+"' ;)", body, "192.168.2.68");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        
        public void SendLimitReachedMail(string userid, decimal rest)
        {
            string userMail;
            string getUserMail = "Select EMail from T_User where UserID = '"+userid+"'";
            using (SqlDataReader rd = _dbConn.GetResult(getUserMail,null))
            {
                rd.Read();
                userMail =  rd.GetValue(0).ToString();
            }
            Form.sendMail(userMail,rest.ToString());
        }
        public void SendMailIfLimitReached(decimal preis, decimal rest,decimal betragsLimit, string userid)
        {
            rest = rest + preis;

            if (rest >= betragsLimit && rest%5 < 1)
            {
                SendLimitReachedMail(userid, rest);
            }
        }
        public void SendMailIfLimitReached(string userid)
        {
            decimal rest;
            decimal limit;
            decimal preis;

            string getData = "Select rest,  BetragsLimit from T_User where UserID = '" + userid + "'";
            using (SqlDataReader reader = _dbConn.GetResult(getData, null))
            {
                reader.Read();
                rest = Convert.ToDecimal(reader.GetValue(0));
                limit = Convert.ToDecimal(reader.GetValue(1));
            }
            string getPreis = "Select TOP 1 Preis from T_Posten where UserID = '" + userid + "' order by Time desc";
            using (SqlDataReader reader = _dbConn.GetResult(getPreis, null))
            {
                reader.Read();
                preis = Convert.ToDecimal(reader.GetValue(0));
            }
            SendMailIfLimitReached(preis, rest, limit, userid);
        }
    }
}
