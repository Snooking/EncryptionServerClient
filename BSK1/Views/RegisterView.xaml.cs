using BSK1.ViewModels;
using System.Windows.Controls;

namespace BSK1.Views
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Page
    {
        public RegisterView()
        {
            InitializeComponent();
            DataContext = new RegisterViewModel();
        }

        private void Password_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox && DataContext is RegisterViewModel registerViewModel)
            {
                registerViewModel.Password = passwordBox.Password;
            }
        }
    }
}
