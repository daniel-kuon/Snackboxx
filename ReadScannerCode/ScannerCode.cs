using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Security;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Snackboxx.Core;


namespace ReadScannerCode
{
    
    public class ScannerCode
    {
        private bool _run = false;
        private Thread _thread = null;
        private string _code = null;
        
        
        

        public ScannerCode()
        { 
            
        }

        private void StartThread()
        {
            _thread = new Thread(new ThreadStart(Run));
            _thread.Start();
        }

        public bool IsRun
        {
            get { return _run; }
        }

        private void Run()
        {
            KeyCheck key = new KeyCheck();
            string text = null;
            while (_run)
            {
                string keys = key.GetKey();
                //LogFile.WriteData("RunThread..."+keys, "c:\\tmp\\A");
                
                
                if (!string.IsNullOrEmpty(keys))
                {
                    text += keys;
                    text = text.Replace("_enter_", "\n");
                    if (text.IndexOf("\n") > -1)
                    {
                        _code = text;
                        text = null;
                    }
                }
                Thread.Sleep(10);
            }
        }

        public void Stop()
        {
            _run = false;
            if (_thread != null) if (_thread.IsAlive) _thread.Abort();
            _thread = null;
        }

        public void Start()
        {
            _run = true;
            if (_thread != null) if (_thread.IsAlive) _thread.Abort();
            this.StartThread();            
        }

        public string GetCode()
        {
            string tmpcode = null;
            if (!string.IsNullOrEmpty(_code))
            {
                tmpcode = _code;
                _code = null;
                return tmpcode;
            }
            return null;
        }

        protected class KeyCheck
        {
            string keyBuffer = null;


            [DllImport("user32.dll")]
            static extern bool GetAsyncKeyState(System.Windows.Forms.Keys vKey);

            [DllImport("User32.dll")]
            private static extern short GetAsyncKeyState(System.Int32 vKey);

            [DllImport("User32.dll")]
            static extern int GetForegroundWindow();

            public static bool IsKeyPushedDown(System.Windows.Forms.Keys vKey)
            {
                //LogFile.WriteLog("KeyDown..." + vKey.ToString(),"C:\\tmp\\B");
                return 0 != (GetAsyncKeyState((int)vKey) & 0x8000);
            }
            public KeyCheck()
            {

            }

            private bool Correctkey(string key)
            {
                bool correct = false;
                string pattern = @"^[0-9]";
                string pattern2 = "_enter_";
                correct = Regex.IsMatch(key, pattern);
                if (!correct) correct = Regex.IsMatch(key, pattern2);
                return correct;
            }

            public string GetKey()
            {
                keyBuffer = null;

                

                foreach (System.Int32 i in Enum.GetValues(typeof(Keys)))
                {
                    int x = GetAsyncKeyState(i);
                    //LogFile.WriteLog("AsyncKey... " + x.ToString(), "C:\\tmp\\C");
                    if ((x == 1) || (x == -32767))
                    {
                        keyBuffer += Enum.GetName(typeof(Keys), i) + " ";//this is WinAPI listener of the keys
                        //LogFile.WriteLog("Key: "+keyBuffer.ToString(),"C:\\tmp\\D");
                    }
                }


                if (!string.IsNullOrEmpty(keyBuffer))
                {
                    #region old
                    // replacing of unreadable keys              
                    /*keyBuffer = keyBuffer.Replace("Space", "_");
                    keyBuffer = keyBuffer.Replace("Delete", "_Del_");
                    keyBuffer = keyBuffer.Replace("LShiftKey", "_SHIFT_");
                    keyBuffer = keyBuffer.Replace("ShiftKey", "");
                    keyBuffer = keyBuffer.Replace("OemQuotes", "!");
                    keyBuffer = keyBuffer.Replace("Oemcomma", "?");
                    keyBuffer = keyBuffer.Replace("D8", "á");
                    keyBuffer = keyBuffer.Replace("D2", "ě");
                    keyBuffer = keyBuffer.Replace("D3", "š");
                    keyBuffer = keyBuffer.Replace("D4", "č");
                    keyBuffer = keyBuffer.Replace("D5", "ř");
                    keyBuffer = keyBuffer.Replace("D6", "ž");
                    keyBuffer = keyBuffer.Replace("D7", "ý");
                    keyBuffer = keyBuffer.Replace("D9", "í");
                    keyBuffer = keyBuffer.Replace("D0", "é");
                    keyBuffer = keyBuffer.Replace("Back", "<==");
                    keyBuffer = keyBuffer.Replace("LButton", "");
                    keyBuffer = keyBuffer.Replace("RButton", "");
                    keyBuffer = keyBuffer.Replace("OemPeriod", ".");
                    keyBuffer = keyBuffer.Replace("OemSemicolon", "ů");
                    keyBuffer = keyBuffer.Replace("Oem4", "/");
                    keyBuffer = keyBuffer.Replace("LControlKey", "");
                    keyBuffer = keyBuffer.Replace("ControlKey", "_CTRL_");
                    keyBuffer = keyBuffer.Replace("Shift", "____SHIFT___");
                    */
                    #endregion

                    keyBuffer = keyBuffer.Replace("D0", "0");
                    keyBuffer = keyBuffer.Replace("D1", "1");
                    keyBuffer = keyBuffer.Replace("D2", "2");
                    keyBuffer = keyBuffer.Replace("D3", "3");
                    keyBuffer = keyBuffer.Replace("D4", "4");
                    keyBuffer = keyBuffer.Replace("D5", "5");
                    keyBuffer = keyBuffer.Replace("D6", "6");
                    keyBuffer = keyBuffer.Replace("D7", "7");
                    keyBuffer = keyBuffer.Replace("D8", "8");
                    keyBuffer = keyBuffer.Replace("D9", "9");
                    keyBuffer = keyBuffer.Replace("NumPad", "");
                    keyBuffer = keyBuffer.Replace("Enter", "_ENTER_");
                    keyBuffer = keyBuffer.ToLower();
                    keyBuffer = keyBuffer.Replace(" ", "");

                    if (Correctkey(keyBuffer))
                    {
                        return keyBuffer;
                    }
                }
                return null;
            }
        }
    }


}
