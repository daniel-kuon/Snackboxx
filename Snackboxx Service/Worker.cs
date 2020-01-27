using System;
using System.Collections.Generic;
using System.Text;
using ReadScannerCode;
using Snackboxx.Core;
using System.Windows.Forms;
using System.IO;
using System.Threading;


namespace Snackboxx_Service
{
    public class Worker
    {
        private ScannerCode _scannercode = new ScannerCode();
        private ReadIni _readini = null;
        private WriteIni _writeini = null;
        private Snackboxx.Core.DBConnection _dbconn = new DBConnection();
        private string _installpath = null;
        private string _inipath = Environment.CurrentDirectory + "\\Config\\option.ini";
        private IniObj _iniObj = new IniObj();
        private bool _ready = false;
        private bool _threadrun = false;

        
        public Worker()
        {
            _writeini = new WriteIni();
            
        }

        public void Start()
        {
            this.Startparameter();
           LogFile.WriteLog("Start Snackboxx Service...",_installpath);
           if (!_readini.ConfigFileExists())
           {
               LogFile.WriteLog("Ini File not exists...", _installpath);
               DirectoryInfo di = new DirectoryInfo(_inipath.Substring(0,_inipath.LastIndexOf("\\")));
               if(!di.Exists)di.Create();
               _writeini.Write(_inipath, _iniObj);
           }
           else
           {
               this.ReadIni();
               _ready = true;
               _scannercode.Start();
               try
               {
                   SQLConnObj sqlObj = _dbconn.Connection(_iniObj.Server, _iniObj.Database, _iniObj.User, _iniObj.Password);
                   if (!sqlObj.isConnect)
                   {
                       _ready = false;
                       LogFile.WriteLog("SQL Exception... " + sqlObj.exp.Message);
                   }
                   else
                   {
                       LogFile.WriteLog("Database connected...");
                       _threadrun = true;
                       Thread runner = new Thread(new ThreadStart(Runner));
                       runner.Start();
                   }
               }
               catch (Exception exp)
               {
                   LogFile.WriteLog("Exception... " + exp.Message);
               }                 
           }                     
        }

        public void Stop()
        {
            _threadrun = false;
            _scannercode.Stop();
            _dbconn.SQLClose();
            LogFile.WriteLog("Stop Snackboxx Service...",_installpath);
            
        }

        public void Pause()
        {
            LogFile.WriteLog("Pause Snackboxx Service...",_installpath);
        }

        private void Startparameter()
        {
            RegistryReader regreader = new RegistryReader();
            regreader.SetRoot(RegistryReader.RegistryRoots.LocalMaschine);
            regreader.RegistryPath = "SYSTEM\\ControlSet001\\Services\\Snackboxx Application";
            regreader.OpenRegistry();
            string value = regreader.GetValue("ImagePath");
            _installpath = value.Substring(0, value.LastIndexOf("\\")).Replace("\"","");
            _inipath = _installpath + "\\Config\\option.ini";
            _readini = new ReadIni(_inipath);

            
            
        }

        private void ReadIni()
        {
            _iniObj = _readini.GetIni();


        }

        public bool Ready
        {
            get { return _ready; }
        }

        private void WriteIni()
        {
            FileInfo fi = new FileInfo(_installpath + "\\option.ini");
            if (!fi.Exists) fi.Create();


            IniObj iniObj = new IniObj();
            iniObj.Database = "";
            iniObj.Server = "";
            iniObj.User = "";
            iniObj.Password = "";


            _writeini.Write(fi.FullName, iniObj);
        }

        private void Runner()
        {
            LogFile.WriteLog("Thread \"Runner\" is started..."+_threadrun);
            LogFile.WriteLog("Thread \"ScannerCode\" is started..." + _scannercode.IsRun);
            while (_threadrun)
            {
                string code = _scannercode.GetCode();
                LogFile.WriteData(code, _installpath);
                if (!string.IsNullOrEmpty(code))
                {
                    LogFile.WriteLog(code, _installpath);
                }
                Thread.Sleep(20);
            }
        }

        protected class Work
        {
            public Work()
            { 
                
            }
        }
    }
}
