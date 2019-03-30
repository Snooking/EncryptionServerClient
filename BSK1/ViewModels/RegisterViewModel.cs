namespace BSK1.ViewModels
{
    internal class RegisterViewModel : BaseViewModel
    {
        public string Password { get; set; }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public RelayCommand RegisterCommand => new RelayCommand(Register, (_) => CanRegister());

        private void Register()
        {
            System.Console.WriteLine($"{Name} {Password}");
        }

        private bool CanRegister()
        {
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Password);
        }
    }
}
