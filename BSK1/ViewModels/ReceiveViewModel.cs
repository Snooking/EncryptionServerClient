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
    internal class ReceiveViewModel : BaseViewModel
    {
        private const string ReadPath = "E:\\Temp\\";

        private string _originalName;
        public string OriginalName
        {
            get => _originalName;
            set
            {
                _originalName = value;
                if (value != null)
                {
                    Extension = value.Split('.')[1];
                }
                OnPropertyChanged(nameof(OriginalName));
            }
        }

        private string _newName;
        public string NewName
        {
            get => _newName;
            set
            {
                _newName = value;
                OnPropertyChanged(nameof(NewName));
            }
        }

        private string _extension;
        public string Extension
        {
            get => _extension;
            set
            {
                _extension = value;
                OnPropertyChanged(nameof(Extension));
            }
        }

        private string _path;
        public string SelectedPath
        {
            get => _path;
            set
            {
                _path = value;
                OnPropertyChanged(nameof(SelectedPath));
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

        public ReceiveViewModel()
        {
            OriginalName = "ShortcutsToLearn.md";
            Algorithms = new ObservableCollection<string>
            {
                "ECB",
                "CBC",
                "CFB",
                "OFB"
            };
            Users = GetAllUsers();
        }

        public RelayCommand ChooseFileCommand => new RelayCommand(() =>
        {

            var fileDialog = new OpenFileDialog
            {
                ValidateNames = false,
                CheckFileExists = false,
                CheckPathExists = true,
                Filter = "Image files (a.bmp)|a.bmp|All files (a.a)|a.a",
                FileName = "~"
            };
            if ((bool)fileDialog.ShowDialog())
            {
                SelectedPath = Path.GetDirectoryName(fileDialog.FileName);
            }
        });

        public RelayCommand ReceiveFileCommand => new RelayCommand(ReceiveFile,
                (_) => SelectedAlgorithm != null && SelectedUser != null && OriginalName != null 
                && Directory.Exists(SelectedPath) && NewName != null);

        public RelayCommand AbortFileCommand => new RelayCommand(AbortFile,
                (_) => OriginalName != null);

        private void ReceiveFile()
        {
            Task.Run(() =>
            {
                while (Progress < 100)
                {
                    Thread.Sleep(100);
                    Progress++;
                }
            });

            var reader = new FileReader(ReadPath + OriginalName);
            var text = reader.ReadFile();
            var decrypter = new Decrypter(text, (CipherMode)Enum.Parse(typeof(CipherMode), SelectedAlgorithm));
            var decryptedText = decrypter.Decrypt();
            var writer = new FileWriter(SelectedPath + "\\" + NewName + "." + Extension, decryptedText);
            writer.WriteToFile();
        }

        private void AbortFile()
        {
            OriginalName = null;
        }
    }
}
