using BSK1.Views;

namespace BSK1.ViewModels
{
    internal class ApplicationViewModel : BaseViewModel
    {
        private ApplicationPage _currentPage = ApplicationPage.Send;
        public ApplicationPage CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        public RelayCommand SendPageCommand => new RelayCommand(() => CurrentPage = ApplicationPage.Send); 
        public RelayCommand ReceivePageCommand => new RelayCommand(() => CurrentPage = ApplicationPage.Receive);
        public RelayCommand UsersPageCommand => new RelayCommand(() => CurrentPage = ApplicationPage.Users);
        public RelayCommand RegisterPageCommand => new RelayCommand(() => CurrentPage = ApplicationPage.Register);
    }
}
