using System.Windows;
using WPF.viewModel;

namespace WPF
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            DataContext = new AdminViewModel();
        }
    }
}
