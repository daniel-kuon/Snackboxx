using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Snackboxx.Annotations;
using Snackboxx.Core;
using MessageBox = System.Windows.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace Snackboxx.WpfControls
{
    /// <summary>
    /// Interaction logic for Config.xaml
    /// </summary>
    public partial class Config : UserControl, INotifyPropertyChanged
    {
        private IniObj _iniFile = new ReadIni(SnackboxxForm.IniFilePath).GetIni();

        public Config()
        {
            InitializeComponent();
        }

        public IniObj IniFile
        {
            get => _iniFile;
            set
            {
                if (value.Equals(_iniFile)) return;
                _iniFile = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OpenScanLogPath(object sender, RoutedEventArgs e)
        {
            Process.Start("Explorer.exe", IniFile.ScanLogPath);
        }

        private void SelectScanLogPath(object sender, RoutedEventArgs e)
        {
            using var dialog = new FolderBrowserDialog() {SelectedPath = IniFile.ScanLogPath};
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            IniFile.ScanLogPath = dialog.SelectedPath;
        }

        private void CheckDatabase(object sender, RoutedEventArgs e)
        {
            var testConnection = new DBConnection().TestConnection(IniFile.Server, IniFile.Database, IniFile.User, IniFile.Password);
            if (testConnection.isConnect)
                MessageBox.Show("Database connection works");
            else
                MessageBox.Show("Database connection failed\n" + testConnection.exp);
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                new WriteIni().Write(SnackboxxForm.IniFilePath, IniFile);
                MessageBox.Show("Config Saved");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Saving failed\n" + exception.Message);
            }
        }

        private void Reload(object sender, RoutedEventArgs e)
        {
            IniFile = new ReadIni(SnackboxxForm.IniFilePath).GetIni();
            MessageBox.Show("Config loaded");
        }
    }
}