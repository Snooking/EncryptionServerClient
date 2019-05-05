using BSK1.Crypting;
using BSK1.Models;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace BSK1.ViewModels
{
    internal class SendViewModel : BaseViewModel
    {
        private const string SendingPath = "E:\\Temp\\";

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

        public RelayCommand ChooseFileCommand => new RelayCommand(() =>
        {
            var fileDialog = new OpenFileDialog();
            if ((bool)fileDialog.ShowDialog())
            {
                Path = fileDialog.FileName;
            }
        });

        public RelayCommand SendFileCommand => new RelayCommand(SendFile,
                (_) => SelectedAlgorithm != null && SelectedUser != null && File.Exists(Path));

        public SendViewModel()
        {
            Algorithms = new ObservableCollection<string>
            {
                "ECB",
                "CBC",
                "CFB",
                "OFB"
            };
            Users = GetAllUsers();
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

            var reader = new FileReader(Path);
            var text = reader.ReadFile();
            var encrypter = new Encrypter(text, (CipherMode)Enum.Parse(typeof(CipherMode), SelectedAlgorithm));
            var encryptedText = encrypter.Encrypt();
            var fileName = Path.Split('\\');
            var writer = new FileWriter(SendingPath + fileName[fileName.Length - 1], encryptedText);
            writer.WriteToFile();
        }
    }
}
