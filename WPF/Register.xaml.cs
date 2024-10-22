using System.Windows;
using WPF.viewModel;

namespace WPF
{
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
            var viewModel = new RegisterViewModel();
            DataContext = viewModel;
            viewModel.CloseAction = new Action(this.Close);


        }
    }
}
