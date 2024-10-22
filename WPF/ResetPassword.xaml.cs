using System.Windows;
using WPF.viewModel;

namespace WPF
{
    /// <summary>
    /// Interaction logic for ResetPassword.xaml
    /// </summary>
    public partial class ResetPassword : Window
    {
        public ResetPassword()
        {
            InitializeComponent();
            ResetPasswordViewModel viewModel = new ResetPasswordViewModel();
            this.DataContext = viewModel;
            viewModel.CloseAction = new Action(this.Close);
        }
    }
}
