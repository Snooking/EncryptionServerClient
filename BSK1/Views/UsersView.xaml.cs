using BSK1.ViewModels;
using System.Windows.Controls;

namespace BSK1.Views
{
    /// <summary>
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : Page
    {
        public UsersView()
        {
            InitializeComponent();
            DataContext = new UsersViewModel();
        }

        private void Password_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox && DataContext is UsersViewModel usersViewModel)
            {
                usersViewModel.Password = passwordBox.Password;
            }
        }
    }
}
