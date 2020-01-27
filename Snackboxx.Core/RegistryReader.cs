using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Snackboxx.Core
{
    public class RegistryReader
    {
        private RegistryKey _regkey;
        private string _path = "Software\\";

        public enum RegistryRoots { CurrentUser, LocalMaschine, CurrentConfig, Users }

        public RegistryReader()
        {            
            _regkey = Registry.CurrentUser;
        }

        public string RegistryPath
        {
            get { return _path; }
            set { _path = value; }
        }

        public void SetRoot(RegistryRoots roots)
        {
            if (roots.Equals(RegistryRoots.CurrentConfig))
                _regkey = Registry.CurrentConfig;
            if (roots.Equals(RegistryRoots.CurrentUser))
                _regkey = Registry.CurrentUser;
            if (roots.Equals(RegistryRoots.LocalMaschine))
                _regkey = Registry.LocalMachine;
            if (roots.Equals(RegistryRoots.Users))
                _regkey = Registry.Users;
        }        

        public void OpenRegistry()
        {
            _regkey = _regkey.OpenSubKey(_path, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl);
        }

        public void CloseRegistry()
        {
            _regkey.Close();
        }

        public bool SubRegExists()
        {
            if (_regkey.ValueCount > 0)
                return true;
            return false;
        }

        public string GetValue(string key)
        {
            return _regkey.GetValue(key).ToString();
        }

        public string[,] GetParams()
        {
            string[,] param = new string[_regkey.ValueCount, 2];
            string[] keyname = _regkey.GetValueNames();
            for (int i = 0; i < _regkey.ValueCount; ++i)
            {
                param[i, 0] = keyname[i].ToString();
                param[i, 1] = _regkey.GetValue(keyname[i].ToString()).ToString();
            }
            return param;
        }

        public void UpdateParam(string key, object value)
        {
            _regkey.SetValue(key, value);
        }

        public void DeleteParam(string key)
        {
            _regkey.DeleteValue(key);
        }
    }
}
