using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Snackboxx.Core
{
    
    public static class LogFile
    {
        private static string _path = Environment.CurrentDirectory+"\\Log\\";
        private static string _filename = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day;

        


        public static void WriteLog(string text)
        {
            DirectoryInfo di = new DirectoryInfo(_path);
            if (!di.Exists) di.Create();
            StreamWriter sr = new StreamWriter(di.FullName + "\\Log_" + _filename+ ".log", true);
            sr.WriteLine(DateTime.Now + " " + text);
            sr.Close();
        }
        public static void WriteLog(string text, string path)
        {
            _path = path+"\\Log\\";            
            DirectoryInfo diI = new DirectoryInfo(_path);
            if (!diI.Exists) diI.Create();
            StreamWriter sr = new StreamWriter(diI.FullName + "\\Log_" + _filename + ".log", true);
            sr.WriteLine(DateTime.Now + " " + text);
            sr.Close();
            
        }
        public static void WriteData(string text, string path)
        {
            path += "\\Log\\";
            DirectoryInfo diI = new DirectoryInfo(path);
            if (!diI.Exists) diI.Create();
            StreamWriter sr = new StreamWriter(diI.FullName + "\\Data_" + _filename + ".txt", true);
            sr.WriteLine(DateTime.Now + " " + text);
            sr.Close();
        }
    }
}
