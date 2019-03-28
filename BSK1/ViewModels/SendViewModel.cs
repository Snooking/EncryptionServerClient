using BSK1.Models;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BSK1.ViewModels
{
    internal class SendViewModel : BaseViewModel
    {
        private string _path;
        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                OnPropertyChanged(nameof(Path));
            }
        }

        private ObservableCollection<string> _algorithms;
        public ObservableCollection<string> Algorithms
        {
            get => _algorithms;
            set
            {
                _algorithms = value;
                OnPropertyChanged(nameof(Algorithms));
            }
        }

        private string _selectedAlgorithm;
        public string SelectedAlgorithm
        {
            get => _selectedAlgorithm;
            set
            {
                _selectedAlgorithm = value;
                OnPropertyChanged(nameof(SelectedAlgorithm));
            }
        }

        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        private int _progress;
        public int Progress
        {
            get => _progress;
            set
            {
                _progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        }

        public RelayCommand ChooseFileCommand { get; set; }
        public RelayCommand SendFileCommand { get; set; }

        public SendViewModel()
        {
            ChooseFileCommand = new RelayCommand(() =>
            {
                var fileDialog = new OpenFileDialog();
                if ((bool)fileDialog.ShowDialog())
                {
                    Path = fileDialog.FileName;
                }
            });
            SendFileCommand = new RelayCommand(SendFile, 
                (_) => SelectedAlgorithm != null && SelectedUser != null && File.Exists(Path));
            Algorithms = new ObservableCollection<string>
            {
                "ECB",
                "CBC",
                "CFB",
                "OFB"
            };
    Users = new ObservableCollection<User>
            {
                new User
                {
                    Name = "Test1"
                },
                new User
                {
                    Name = "Test2"
                }
            };
        }

        private void SendFile()
        {
            Task.Run(() =>
            {
                while (Progress < 100)
                {
                    Thread.Sleep(100);
                    Progress++;
                }
            });
        }
    }
}
