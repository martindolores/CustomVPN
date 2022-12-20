using CustomVPN.Core;
using CustomVPN.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomVPN.MVVM.ViewModel
{
    class ProtectionViewModel : ObservableObject
    {
        public ObservableCollection<ServerModel> Servers { get; set; }
        public RelayCommand ConnectCommand { get; set; }
        public RelayCommand DisconnectCommand { get; set; }
        private string _connectionStatus;
        private Visibility _connectButtonVisible;

        public Visibility ConnectButtonVisible
        {
            get { return _connectButtonVisible; }
            set
            {
                _connectButtonVisible = value;
                OnPropertyChanged(nameof(ConnectButtonVisible));
            }
        }

        private Visibility _disconnectButtonVisible;

        public Visibility DisconnectButtonVisible
        {
            get { return _disconnectButtonVisible; }
            set
            {
                _disconnectButtonVisible = value;
                OnPropertyChanged(nameof(DisconnectButtonVisible));
            }
        }

        public string ConnectionStatus
        {
            get { return _connectionStatus; }
            set
            {
                _connectionStatus = value;
                OnPropertyChanged();
            }
        }

        public ProtectionViewModel()
        {
            ConnectButtonVisible = Visibility.Visible;
            DisconnectButtonVisible = Visibility.Hidden;
            Servers = new ObservableCollection<ServerModel>();
            for (int i = 0; i < 10; i++)
            {
                Servers.Add(new ServerModel
                {
                    Country = "USA"
                });
            }
            ConnectCommand = new RelayCommand(o =>
            {
                Task.Run(() =>
                {
                    ConnectionStatus = "Connecting...";
                    var process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                    process.StartInfo.ArgumentList.Add(@"/c rasdial MyServer vpnbook rxtasfh /phonebook:./VPN/VPN.pbk");
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    process.WaitForExit();
                    switch (process.ExitCode)
                    {
                        case 0:
                            Debug.WriteLine("Sucess!");
                            ConnectionStatus = "Connected!";
                            ConnectButtonVisible = Visibility.Hidden;
                            DisconnectButtonVisible = Visibility.Visible;
                            break;
                        case 691:
                            Debug.WriteLine("Wrong credentials!");
                            ConnectionStatus = "Wrong credentials!";
                            break;
                        default:
                            Debug.WriteLine($"Error: {process.ExitCode}");
                            break;
                    }
                });
            });
            DisconnectCommand = new RelayCommand(o =>
            {
                Task.Run(() =>
                {
                    ConnectionStatus = "Disconnecting...";
                    var process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = @"/c rasdial /d";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    process.WaitForExit();
                    ConnectButtonVisible = Visibility.Visible;
                    DisconnectButtonVisible = Visibility.Hidden;
                    ConnectionStatus = "";
                });
            });
        }

        private void ServerBuilder()
        {
            var address = "us1.vpnbook.com";
            var FolderPath = $"{Directory.GetCurrentDirectory()}/VPN";
            var PbkPath = $"{FolderPath}/{address}.pbk";
            var sb = new StringBuilder();
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            if (File.Exists(PbkPath))
            {
                MessageBox.Show("Connection already exists!");
                return;
            }
            sb.AppendLine("[MyServer]");
            sb.AppendLine("MEDIA=rastapi");
            sb.AppendLine("Port=VPN2-0");
            sb.AppendLine("Device=WAN Miniport (IKEv2)");
            sb.AppendLine("DEVICE=vpn");
            sb.AppendLine($"PhoneNumber={address}");
            File.WriteAllText(PbkPath, sb.ToString());
        }
    }
}
