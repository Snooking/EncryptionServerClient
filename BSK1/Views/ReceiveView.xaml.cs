using BSK1.ViewModels;
using System.Windows.Controls;

namespace BSK1.Views
{
    /// <summary>
    /// Interaction logic for ReceiveView.xaml
    /// </summary>
    public partial class ReceiveView : Page
    {
        public ReceiveView()
        {
            InitializeComponent();
            DataContext = new ReceiveViewModel();
        }
    }
}
