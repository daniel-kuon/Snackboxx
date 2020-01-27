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
using System.Diagnostics;
using System.Linq;
using Snackboxx.Core;
using ReadScannerCode;
using System.Threading;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Snackboxx.UserControls
{
    public partial class Input : UserControl
    {
        private IniObj _iniObj;
        private int _maxlines;
        private bool _scannerrun = false;
        private ScannerCode _scannercode;
        private DBConnection _dbconn;
        public Input input;
        private Stopwatch _stopwatchBlinker = new Stopwatch();
        private bool _lastCodeExists;
        private DateTime _dateTime;
        private List<ScanEntry> _scanEntries = new List<ScanEntry>();
        public Members Members;
        public SnackboxxForm Form;
        public List<UserRight> rights;
        public Textmail.sendmail SendMail;
        

        public Input(IniObj iniObj, SnackboxxForm snackboxxform, DBConnection dbconn,  List<UserRight> rights)
        {
            InitializeComponent();
            _iniObj = iniObj;
            _dbconn = dbconn;
            Form = snackboxxform;

            Members = new Members(dbconn, snackboxxform, rights);
        }
        private void Input_Load(object sender, EventArgs e)
        {
            _scannercode = new ScannerCode();
            cbglobalkey.Checked = _iniObj.GlobalKey;
            _maxlines = _iniObj.MaxRtbLines;
            tbmaxloglines.Text = _maxlines.ToString();

            this.WriteInfoLog("Database Connection is " + _dbconn.GetState.ToString() + " ...");
        }
        private void cbglobalkey_CheckedChanged(object sender, EventArgs e)
        {
            if (cbglobalkey.Checked)
            {
                tbinput.Enabled = false;
                _scannerrun = true;
                Thread codeTh = new Thread(new ThreadStart(ScannerRun));
                codeTh.Start();
                this.WriteInfoLog("Autoscan is running...");
            }
            else
            {
                _scannerrun = false;
                tbinput.Enabled = true;
                this.WriteInfoLog("Autoscan stopped...");
            }
        }
        private void ClearLogtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
        }
        private void rtbLog_TextChanged(object sender, EventArgs e)
        {
            ClearLogtoolStripMenuItem.Image = Snackboxx.Properties.Resources.Recycle_Bin_Full;
            if (rtbLog.Lines.GetLength(0) >= _maxlines)
            {
                rtbLog.Clear();
                ClearLogtoolStripMenuItem.Image = Snackboxx.Properties.Resources.Recycle_Bin_Empty;
            }
        }
        private void tbinput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToString().Equals("Return"))
            {
                string codes = tbinput.Text;
                tbinput.Text = string.Empty;
                WriteCode(codes);
            }
        }
        private void tbmaxloglines_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _maxlines = Convert.ToInt32(tbmaxloglines.Text);
            }
            catch (Exception exp)
            {

            }
        }
        private delegate void WriteCodeDel(string code);
        private void WriteCode(string code)
        {
            lablastinput.Text = DateTime.Now.ToString() + "  " + code;
            this.WriteInfo(code);
            this.WriteInfotoDB(code.Replace("\n", ""));
        }
        private delegate void WriteInfoDel(string text);
        private void WriteInfo(string text)
        {
            DirectoryInfo di = new DirectoryInfo(_iniObj.ScanLogPath);
            if (!di.Exists) di.Create();
            StreamWriter se = new StreamWriter(di.FullName + "Scan_" + _iniObj.LogFilename + ".txt", true);
            se.WriteLine(DateTime.Now + " " + text);
            se.Close();
            this.WriteInfoLog("Scanresult: " + text);
        }
        public IniObj GetIniObj()
        {
            _iniObj.GlobalKey = cbglobalkey.Checked;
            _iniObj.MaxRtbLines = _maxlines;
            return _iniObj;
        }
        public void Close()
        {
            _scannerrun = false;
        }
        public void SetDBConnection(DBConnection dbconn)
        {
            _dbconn = dbconn;
            this.WriteInfoLog("Database Connection is " + _dbconn.GetState.ToString() + " ...");
        }
        public delegate void WriteInfoLogDel(string text);
        public void WriteInfoLog(string text)
        {
            text = text.Replace("\n", "");
            rtbLog.AppendText(DateTime.Now.ToString() + "  " + text + "\n");
        }
        private void ScannerRun()
        {
            WriteCodeDel wcode = new WriteCodeDel(WriteCode);
            _scannercode.Start();
            while (_scannerrun)
            {
                string code = _scannercode.GetCode();
                if (!string.IsNullOrEmpty(code))
                    this.Invoke(wcode, new object[] { code });
                Thread.Sleep(100);
            }
            _scannercode.Stop();
        }
        private string InsertParameterCheck(string text)
        {
            return text.Replace("'", "").Replace(";", "").Replace("\\", "");
        }
        private void WriteInfotoDB(string text)
        {
            try
            {
                text = this.InsertParameterCheck(text);
                string userid = string.Empty;
                string codeid = string.Empty;
                string username = string.Empty;
                decimal preis = 0;
                bool issnackcode = true;
                string kontoid = string.Empty;
                bool inhouse = false;
                DateTime upddate = DateTime.Now;

                string query = "Select UserID,UserName,CodeID,Preis,IsSnackCode,KontoID,InHouse,UpdateTime from VW_UserCodes where UserCode='" + text + "'";
                decimal rest = 0;
                decimal betragsLimit = 0;
                _lastCodeExists = _dbconn.DataSetExists(query, null);
                if (_dbconn.DataSetExists(query, null))
                {
                    _stopTimers();
                    _scanCodes(text, true);
                    SqlDataReader dr = _dbconn.GetResult(query, null);
                    while (dr.Read())
                    {
                        try
                        {
                            userid = dr.GetValue(0).ToString();
                            username = dr.GetValue(1).ToString();
                            codeid = dr.GetValue(2).ToString();
                            preis = Convert.ToDecimal(dr.GetValue(3).ToString());
                            issnackcode = Convert.ToBoolean(dr.GetValue(4));
                            kontoid = dr.GetValue(5).ToString();
                            if (!dr.IsDBNull(6)) { inhouse = Convert.ToBoolean(dr.GetValue(6)); }
                            if (!dr.IsDBNull(7)) { upddate = Convert.ToDateTime(dr.GetValue(7)); }
                        }
                        catch (SqlException exp)
                        {
                            this.WriteInfo("SQLException: " + exp.Message);
                            dr.Close();
                        }
                    }
                    dr.Close();

                    if (issnackcode)
                    {
                        string restquery = "Select rest, BetragsLimit from T_User where UserID='" + userid + "'";
                        SqlDataReader sqldr = _dbconn.GetResult(restquery, null);
                        while (sqldr.Read())
                        {
                            rest = Convert.ToDecimal(sqldr.GetValue(0).ToString());
                            betragsLimit = Convert.ToDecimal(sqldr.GetValue(1).ToString());
                        }
                        sqldr.Close();
                        Form.SendMailIfLimitReached(preis, rest, betragsLimit, userid);        
                        
                        rest = rest + preis;
                        string insert = string.Format("Insert into T_Posten(UserID,CodeID,Preis)values('{0}','{1}','{2}')", userid, codeid,
                            preis.ToString().Replace(",", "."));
                        _dbconn.Execute(insert, null);
                        string userinsert = "Update T_User set rest='" + rest.ToString().Replace(",", ".") + "' where UserID='" + userid + "'";
                        _dbconn.Execute(userinsert, null);
                        _dateTime = DateTime.Now;
                        this.WriteInfo("Save Posten... " + username + "; " + preis);
                        FlashUserImage(userid, preis);
                    }
                    else
                    {
                        bool iscomming = false;
                        if (!string.IsNullOrEmpty(kontoid))
                        {
                            DateTime time = DateTime.Now;
                            if (time.Day > upddate.Day) { iscomming = true; inhouse = false; }
                            if (!inhouse) { iscomming = true; }
                            inhouse = !inhouse;
                            ParameterObj timeObj = new ParameterObj();
                            timeObj.name = "@Timer";
                            timeObj.type = SqlDbType.DateTime;
                            timeObj.value = time;
                            List<ParameterObj> paramlist = new List<ParameterObj>();
                            paramlist.Add(timeObj);
                            string kquery = "Update T_UserTimeKonto set InHouse='" + inhouse + "',UpdateTime=@Timer where KontoID='" + kontoid + "'";
                            _dbconn.Execute(kquery, paramlist);
                            string ntime = "Insert into T_Time(KontoID,Time,iscomming)values('" + kontoid + "',@Timer,'" + iscomming + "')";
                            _dbconn.Execute(ntime, paramlist);
                        }
                        string inn = "Welcome";
                        if (!iscomming) { inn = "Bye"; }
                        this.WriteInfo("TimeCode... " + inn + " " + username + "!");
                    }
                }
                else
                {
                    this.WriteInfo("UserCode (" + text + ") not exists...");
                    _startTimers();
                    SaveLastUnknownCode(text);
                    _scanCodes(text, false);
                }
            }
            catch (Exception exp)
            {
                this.WriteInfo("Error: " + exp.Message);
            }
        }

        public void SaveLastUnknownCode(string unknownCode)
        {
            string insert = "Insert into T_UnknownCodes(Code)Values('" + unknownCode + "');";
            _dbconn.Execute(insert, null);
            _dateTime = DateTime.Now;
        }

        private void _scanCodes(string text, bool exists)
        {
            ScanEntry _scanEntry = new ScanEntry();
            _scanEntry.DateTime = DateTime.Now;
            _scanEntry.Code = text;
            _scanEntry.Exist = exists;
            _scanEntries.Add(_scanEntry);

            if (_scanEntry.Exist && _scanEntries.Count > 1000)
            {
                _scanEntries.RemoveAt(0);
            }
        }

        private void _startTimers()
        {
            tmrFlashError.Enabled = true;
            _stopwatchBlinker.Start();
        }

        private void _stopTimers()
        {
            tmrFlashError.Enabled = false;
            _stopwatchBlinker.Stop();
            _stopwatchBlinker.Reset();

        }

        private void tmrFlashError_Tick(object sender, EventArgs e)
        {
            int totalTime = 10000;
            long elapsedTime = _stopwatchBlinker.ElapsedMilliseconds;

            if (!label6.Visible)
            {
                label6.Visible = true;
                label6.BackColor = Color.Red;
                label6.Dock = DockStyle.Fill;

                if (totalTime <= elapsedTime)
                {
                    label6.Visible = false;
                    _stopTimers();
                }
            }
            else
            {
                label6.Visible = false;
            }
        }

        private void tmrSendErrorMail_Tick(object sender, EventArgs e)
        {
            TimeSpan timeSpanLimit = new TimeSpan(0, 0, 30);

            if (!_lastCodeExists && _scanEntries.Count > 0)
            {
                foreach (ScanEntry scanEntry in _scanEntries.ToArray())
                {
                    if (!scanEntry.Exist && (DateTime.Now - scanEntry.DateTime) >= timeSpanLimit)
                    {
                        SendEmail(scanEntry);
                        _scanEntries.Remove(scanEntry);
                    }
                }
            }
            else
            {
                _scanEntries.RemoveAll(entry => !entry.Exist);
            }
        }

        private void SendEmail(ScanEntry scanEntry)
        {
            string lastWrongEntryCode = scanEntry.Code;
            string lastWrongEntryTime = scanEntry.DateTime.ToString();

            string lastKnownCodeQuery = "Select Top 1 UserName, UserCode, Preis, Time From VW_Posten order by Time desc;";
            string lastKnownCodePreis;
            string lastKnownCodeTime;
            string lastKnownCodeUserID;
            string lastKnownCode;
            using (SqlDataReader lastKnownCodeReader = _dbconn.GetResult(lastKnownCodeQuery, null))
            {
                lastKnownCodeReader.Read();
                lastKnownCodeUserID = lastKnownCodeReader.GetValue(0).ToString();
                lastKnownCode = lastKnownCodeReader.GetValue(1).ToString();
                lastKnownCodePreis = lastKnownCodeReader.GetValue(2).ToString();
                lastKnownCodeTime = lastKnownCodeReader.GetValue(3).ToString();
            }
            string body = $@"Good day Daniel ! 

Please check out the following Codes 
------------------------------------------------------
Unknown Code: 
Time: {lastWrongEntryTime} 
Code: {lastWrongEntryCode} 

Last recognized Code: 
Time: {lastKnownCodeTime} 
Code: {lastKnownCode} 
UserID: {lastKnownCodeUserID} 
Preis: {lastKnownCodePreis}
------------------------------------------------------



J.A.R.V.I.S.";

            SendMail = new Textmail.sendmail();
            Textmail.sendmail.send("Snackboxx@rohlig.com", "", "Snackboxx error! :c", body, "192.168.2.68");
        }

        private void tmrFortnite_Tick(object sender, EventArgs e)
        {
            tmrFortnite.Enabled = false;
            pnlFortnite.Visible = false;
        }

        private void FlashUserImage(string userId, decimal betrag)
        {
            if (userId == null)
                return;
            var path = Path.Combine(Application.StartupPath, "UserImages");
            var userDir = Directory
                .GetDirectories(path)
                .FirstOrDefault(d => Regex.IsMatch(Path.GetFileName(d), $"^{userId}[^0-9]*"));
            if (userDir == null)
                return;
            var usedPicturesDir = Path.Combine(userDir, "used");
            if (!Directory.Exists(usedPicturesDir))
                Directory.CreateDirectory(usedPicturesDir);
            var availablePictures = Directory.GetFiles(userDir);
            if (availablePictures.Length == 1)
                Directory
                    .GetFiles(usedPicturesDir)
                    .ToList()
                    .ForEach(f => File.Move(f, Path.Combine(userDir, Path.GetFileName(f))));
            var picture = availablePictures[new Random().Next(0, availablePictures.Length - 1)];
            var newPictureLocation = Path.Combine(usedPicturesDir, Path.GetFileName(picture));
            File.Move(picture, newPictureLocation);
            tmrFortnite.Enabled = false;
            picFortnite.ImageLocation = newPictureLocation;
            lblFortnitePrice.Text = betrag.ToString("0.00 €");
            pnlFortnite.Visible = true;
            tmrFortnite.Enabled = true;
        }
    }
}
