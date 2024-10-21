using System.Windows;
using WPF.viewModel;

namespace WPF
{
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
            DataContext = new RegisterViewModel();
        }
    }
}
