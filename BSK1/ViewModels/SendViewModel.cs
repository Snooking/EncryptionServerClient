using System.Collections.ObjectModel;

namespace BSK1.ViewModels
{
    internal class SendViewModel : BaseViewModel
    {
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

        public SendViewModel()
        {
            Algorithms = new ObservableCollection<string>
            {
                "A",
                "B",
                "C",
                "D"
            };
        }
    }
}
