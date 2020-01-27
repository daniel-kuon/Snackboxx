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
using ReadScannerCode;
using System.Threading;

namespace Snackboxx_Service
{
    public class SnackboxxService :ServiceBase
    {
        private Worker _worker = new Worker();
        private bool _run = true;
        
        public SnackboxxService()
        {
            this.ServiceName = "Snackboxx Application";
            this.EventLog.Log = "Application";

            this.CanHandlePowerEvent = true;
            this.CanHandleSessionChangeEvent = true;
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
            this.CanStop = true;

        }

        static void Main()
        {
            ServiceBase.Run(new SnackboxxService());
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            _worker.Start();
            Thread th = new Thread(new ThreadStart(CheckReadys));
            th.Start();

        }

        protected override void OnStop()
        {
            _worker.Stop();
            base.OnStop();            
            this.ExitCode = 0;
        }

        protected override void OnPause()
        {
            _worker.Pause();
            base.OnPause();  
        }

        protected override void OnContinue()
        {
            base.OnContinue();
        }
        
        protected override void OnShutdown()
        {
            _worker.Stop();
            base.OnShutdown();
        }

        protected override void OnCustomCommand(int command)
        {
            base.OnCustomCommand(command);
        
        }

        protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
        {
            return base.OnPowerEvent(powerStatus);
        }

        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            base.OnSessionChange(changeDescription);
        }

        private void CheckReadys()
        {
            while (_run)
            {
                if (!_worker.Ready)
                {
                    _run = false;
                    this.Stop();
                    EventLog.WriteEntry("Worker not ready... Status: " + _worker.Ready.ToString()+"\n"
                    +"Please check the Ini File or Datebase Connection.");
                }
                Thread.Sleep(300);
            }
        }

    }
}
