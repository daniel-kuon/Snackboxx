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
using System.Threading;

namespace Snackboxx.UserControls
{
    public partial class Config : UserControl
    {
        private IniObj _iniObj;
        private SnackboxxForm _snackboxx;
        private DBConnection _dbconn;

        public Config(IniObj iniObj,SnackboxxForm snackboxxform,DBConnection dbconn)
        {
            InitializeComponent();
            _iniObj = iniObj;
            _snackboxx = snackboxxform;
            _dbconn = dbconn;
            this.SetFields();
            this.Connect();
        }

        private void Config_Load(object sender, EventArgs e)
        {
            
        }

        private void SetFields()
        {
            if (!string.IsNullOrEmpty(_iniObj.Database))
                tbdbdatabase.Text = _iniObj.Database;
            if (!string.IsNullOrEmpty(_iniObj.Password))
                tbdbpassword.Text = _iniObj.Password;
            if (!string.IsNullOrEmpty(_iniObj.Server))
                tbdbserver.Text = _iniObj.Server;
            if (!string.IsNullOrEmpty(_iniObj.User))
                tbdbuser.Text = _iniObj.User;
            if (!string.IsNullOrEmpty(_iniObj.ScanLogPath))
                tbscanlogpath.Text = _iniObj.ScanLogPath;
        }

        public void Close()
        { }

        public IniObj GetIniObj()
        {
            _iniObj.Database = tbdbdatabase.Text;
            _iniObj.Server = tbdbserver.Text;
            _iniObj.User = tbdbuser.Text;
            _iniObj.Password = tbdbpassword.Text;
            _iniObj.ScanLogPath = tbscanlogpath.Text;
            _iniObj.ErrorMail = txtErrorMail.Text;
            return _iniObj;
        }

        private void btndbcheck_Click(object sender, EventArgs e)
        {
            SQLConnObj sqlCObj = _dbconn.TestConnection(tbdbserver.Text, tbdbdatabase.Text, tbdbuser.Text, tbdbpassword.Text);
            if (sqlCObj.isConnect)
            {
                //this.WriteLog("Check DataBase... ready");
                labconnstat.Text = "Database is ready...";
                //this.EnableComponents(true);
            }
            else
            {
                labconnstat.Text = "Database is corrupt...";
                //this.WriteLog("Check Database... " + sqlCObj.exp.Message);
            }
        }

        public DBConnection DBConn
        {
            get { return _dbconn; }
        }

        private void savetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _dbconn.SQLClose();
                SQLConnObj sqlCObj = _dbconn.Connection(tbdbserver.Text, tbdbdatabase.Text, tbdbuser.Text, tbdbpassword.Text);
                if (!sqlCObj.isConnect)
                {
                    //this.WriteLog("Save Database config...");
                    _dbconn.SQLOpen();
                    //this.EnableComponents(true);
                    //this.WriteIni();
                    _snackboxx.SetNewDBConnection(ref _dbconn);
                }
                if (_dbconn.GetState == ConnectionState.Closed)
                {
                    //tssInfoONE.Text = "Database is corrupt...";
                    //this.WriteInfo("Save Database Config ... Database is corrupt...");
                    //this.EnableComponents(false);
                }
            }
            catch (Exception exp)
            {
                //this.WriteLog(exp.Message);
            }
        }

        private void Connect()
        {
            try
            {
                _dbconn.SQLClose();
                SQLConnObj sqlCObj = _dbconn.Connection(tbdbserver.Text, tbdbdatabase.Text, tbdbuser.Text, tbdbpassword.Text);
                if (!sqlCObj.isConnect)
                {
                    //this.WriteLog("Save Database config...");
                    _dbconn.SQLOpen();
                    //this.EnableComponents(true);
                    //this.WriteIni();                    
                }
                if (_dbconn.GetState == ConnectionState.Closed)
                {
                    //tssInfoONE.Text = "Database is corrupt...";
                    //this.WriteInfo("Save Database Config ... Database is corrupt...");
                    //this.EnableComponents(false);
                }
            }
            catch (Exception exp)
            {
                //this.WriteLog(exp.Message);
            }
        }

        private void btnscanlogpath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = tbscanlogpath.Text;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbscanlogpath.Text = fbd.SelectedPath;
            }
            fbd.Dispose();
        }
    }
}
