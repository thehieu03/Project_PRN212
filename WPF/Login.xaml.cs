using Responsitories;
using Responsitory.dal;
using Responsitory.Implementations;
using System.Windows;
using WPF.viewModel;

namespace WPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly IUser _iUser;
        public Login()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
            _iUser = new UserResponsitory();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userName = txtUser.Text;
            string passWord = PasswordBox.Password;
            if (userName.Length == 0)
            {
                MessageBox.Show("Enter the User Name");
                return;
            }
            if (passWord.Length == 0)
            {
                MessageBox.Show("Enter the PassWord");
                return;
            }
            var user = _iUser.GetUser(userName, passWord);
            if (user == null)
            {
                MessageBox.Show("Login that bai");
                return;
            }
            int roleID = user.RoleId ?? 0;
            switch (roleID)
            {
                case 1:
                    Admin admin = new Admin();
                    AdminViewModel adminViewModel = new AdminViewModel(user);
                    admin.Show();
                    this.Close();
                    break;
                case 2:
                    Customer customer = new Customer();
                    CustomerViewModel customerViewModel = new CustomerViewModel(user);
                    customer.Show();
                    this.Close();
                    break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Register r = new Register();
            r.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ResetPassword r = new ResetPassword();
            r.Show();
            this.Close();
        }
    }
}
