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
        public RelayCommand SendPageCommand { get; set; }
        public RelayCommand ReceivePageCommand { get; set; }
        public RelayCommand UsersPageCommand { get; set; }

        public ApplicationViewModel()
        {

            SendPageCommand = new RelayCommand(() => CurrentPage = ApplicationPage.Send);
            ReceivePageCommand = new RelayCommand(() => CurrentPage = ApplicationPage.Receive);
            UsersPageCommand = new RelayCommand(() => CurrentPage = ApplicationPage.Users);
        }
    }
}
