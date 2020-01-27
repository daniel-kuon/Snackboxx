using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.Data;
using System.Diagnostics;
using System.Web.Services;
using System.ServiceProcess;

namespace Snackboxx_Service
{
    [RunInstaller(true)]
    public class WinServInstaller:Installer
    {
        public WinServInstaller()
        {
            ServiceProcessInstaller spinstaller = new ServiceProcessInstaller();
            ServiceInstaller sinstaller = new ServiceInstaller();

            spinstaller.Account = ServiceAccount.LocalSystem;
            spinstaller.Username = null;
            spinstaller.Password = null;


            sinstaller.DisplayName = "Snackboxx";
            sinstaller.StartType = ServiceStartMode.Automatic;

            sinstaller.ServiceName = "Snackboxx Application";
            this.Installers.Add(spinstaller);
            this.Installers.Add(sinstaller);

        }
    }
}
