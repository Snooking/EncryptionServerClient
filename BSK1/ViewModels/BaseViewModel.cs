using BSK1.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace BSK1.ViewModels
{
    internal class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private const string UsersDirectory = ".\\Users\\";

        protected ObservableCollection<User> GetAllUsers()
        {
            var users = new ObservableCollection<User>();
            var directories = Directory.GetDirectories(UsersDirectory);
            foreach (var directory in directories)
            {
                users.Add(new User
                {
                    Name = directory.Replace(UsersDirectory, string.Empty)
                });
            }
            return users;
        }
    }
}
