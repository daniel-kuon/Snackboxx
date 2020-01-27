using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;


namespace Snackboxx.Core
{
    public class IniObj
    {
        public string Database { get; set; }
        public string Server { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool GlobalKey { get; set; }
        public string LogFilename { get; set; }
        public int MaxRtbLines { get; set; }
        public string ScanLogPath { get; set; }
        public string LogPath { get; set; }
        public string ErrorMail { get; set; }
    }

    public class ReadIni
    {
        private IniObj _iniObj;
        private bool _ready=false;
        private List<string> _inilist =new List<string>();

        public ReadIni(string file)
        {
            File = file;
            _iniObj = new IniObj();
        }


        public string File { get; set; }

        public bool ConfigFileExists()
        {
            return new FileInfo(File).Exists;
        }

        private void Read()
        {
            _ready = false;
            if (ConfigFileExists())
            {
                _inilist.Clear();
                StreamReader sr = new StreamReader(File, Encoding.UTF8);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    _inilist.Add(line);
                    if (!line.StartsWith("#"))
                    {
                        string[] res = line.Split(new string[] { "=" }, StringSplitOptions.None);
                        if (res.GetLength(0) == 2)
                        {
                            FillIniObj(res[0], res[1]);
                        }
                    }
                }
                sr.Close();
            }
            _ready = true;
        }
        
        private void FillIniObj(string key, string value)
        {
            switch (key)
            { 
                case "Database":
                    _iniObj.Database = value;
                    break;
                case "Server":
                    _iniObj.Server = value;
                    break;
                case "User":
                    _iniObj.User = value;
                    break;
                case "Password":
                    _iniObj.Password = value;
                    break;
                case "GlobalKey":
                    _iniObj.GlobalKey = Convert.ToBoolean(value);
                    break;
                case "maxrtblines":
                    _iniObj.MaxRtbLines = Convert.ToInt32(value);
                    break;
                case "ScanLogPath":
                    _iniObj.ScanLogPath = value;
                    break;
                case "LogPath":
                    _iniObj.LogPath = value;
                    break;
                case "ErrorMail":
                    _iniObj.ErrorMail = value;
                    break;
            }
        }

        public IniObj GetIni()
        {
            this.Read();
            while (!_ready) { }
            return _iniObj;
        }

        public List<string> GetIniList()
        {
            //this.Read();
            return _inilist;
        }
    }
    
    public class WriteIni 
    {
        private ReadIni _readini;
        private string _file;
        private IniObj _iniObj;
        
        public WriteIni()
        {            
        }

        public void Write(string file, IniObj iniobj)
        {
            _file = file;
            _iniObj = iniobj;
            _readini = new ReadIni(file);
            Writer();
        }       

        private void Writer()
        {
            bool database = false,
                 server = false,
                 user = false,
                 password = false,
                 globalKey = false,
                 maxRtbLines = false,
                 scanLogPath = false,
                 logPath = false,
                 errorMail = false;
                 

            StreamWriter sw = new StreamWriter(_file, false, Encoding.UTF8);
            var iniList= _readini.GetIniList();
            for (int i = 0; i < iniList.Count; ++i)
            { 
                string line = iniList[i];

                if (line.StartsWith("Database="))
                {
                    sw.WriteLine("Database=" + _iniObj.Database);
                    database = true;
                }
                else if (line.StartsWith("Server="))
                {
                    sw.WriteLine("Server=" + _iniObj.Server);
                    server = true;
                }
                else if (line.StartsWith("User="))
                {
                    sw.WriteLine("User=" + _iniObj.User);
                    user = true;
                }
                else if (line.StartsWith("Password="))
                {
                    sw.WriteLine("Password=" + _iniObj.Password);
                    password = true;
                }
                else if (line.StartsWith("GlobalKey="))
                {
                    sw.WriteLine("GlobalKey=" + _iniObj.GlobalKey);
                    globalKey = true;
                }
                else if (line.StartsWith("maxrtblines="))
                {
                    sw.WriteLine("maxrtblines=" + _iniObj.MaxRtbLines);
                    maxRtbLines = true;
                }
                else if (line.StartsWith("ScanLogPath="))
                {
                    sw.WriteLine("ScanLogPath=" + _iniObj.ScanLogPath);
                    scanLogPath = true;
                }
                else if (line.StartsWith("LogPath="))
                {
                    sw.WriteLine("LogPath=" + _iniObj.LogPath);
                    logPath = true;
                } 
                else if (line.StartsWith("ErrorMail="))
                {
                    sw.WriteLine("ErrorMail=" + _iniObj.ErrorMail);
                    errorMail = true;
                } 
                else
                    sw.WriteLine(line);
            }
            if(!database)
                sw.WriteLine("Database=" + _iniObj.Database);
            if(!server)
                sw.WriteLine("Server=" + _iniObj.Server);
            if(!user)
                sw.WriteLine("User=" + _iniObj.User);
            if(!password)
                sw.WriteLine("Password=" + _iniObj.Password);
            if (!globalKey)
                sw.WriteLine("GlobalKey=" + _iniObj.GlobalKey);
            if (!maxRtbLines)
                sw.WriteLine("maxrtblines=" + _iniObj.MaxRtbLines);
            if (!scanLogPath)
                sw.WriteLine("ScanLogPath=" + _iniObj.ScanLogPath);
            if (!logPath)
                sw.WriteLine("LogPath=" + _iniObj.LogPath);
            if (!errorMail)
                sw.WriteLine("ErrorMail=" + _iniObj.ErrorMail);
            sw.Close();
        }



    }
}
