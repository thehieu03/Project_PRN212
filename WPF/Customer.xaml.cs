using System.Windows;
using WPF.viewModel;

namespace WPF
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Window
    {
        public Customer()
        {
            InitializeComponent();
            DataContext = new CustomerViewModel();
        }
    }
}
