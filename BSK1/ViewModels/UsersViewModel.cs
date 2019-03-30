using BSK1.Models;
using System.Collections.ObjectModel;

namespace BSK1.ViewModels
{
    internal class UsersViewModel : BaseViewModel
    {
        public string Password { get; set; }

        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged(nameof(_users));
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

        public RelayCommand LoginCommand => new RelayCommand(Login, (_) => CanLogin());

        public UsersViewModel()
        {
            Users = GetAllUsers();
        }

        private void Login()
        {
        }

        private bool CanLogin()
        {
            return SelectedUser != null && !string.IsNullOrEmpty(Password);
        }
    }
}
