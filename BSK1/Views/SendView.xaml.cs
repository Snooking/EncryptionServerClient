using BSK1.ViewModels;
using System.Windows.Controls;

namespace BSK1.Views
{
    /// <summary>
    /// Interaction logic for SendView.xaml
    /// </summary>
    public partial class SendView : Page
    {
        public SendView()
        {
            InitializeComponent();
            DataContext = new SendViewModel();
        }
    }
}
