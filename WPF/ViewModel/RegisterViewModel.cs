using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Responsitory.dal;
using Responsitory.Implementations;
using System.Windows;

namespace WPF.viewModel
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly validate.Validate v = new validate.Validate();
        private readonly IUser iUser = new UserResponsitory();
        [ObservableProperty]
        private string username;
        [ObservableProperty]
        private string email;
        [ObservableProperty]
        private bool isMale = true;
        [ObservableProperty]
        private bool isFemale;
        [ObservableProperty]
        private string address;
        [ObservableProperty]
        private string password;
        [ObservableProperty]
        private int otpCode;
        [RelayCommand]
        private void Save()
        {
            if (v.checkStringIsNull(Username))
            {
                MessageBox.Show("Enter the username");
                return;
            }
            if (v.checkEmail(Email))
            {
                MessageBox.Show("Email khong hợp lệ");
                return;
            }
            if (v.checkStringIsNull(Address))
            {
                MessageBox.Show("Enter the Address");
                return;
            }
            if (v.checkStringIsNull(Password))
            {
                MessageBox.Show("Enter the Password");
                return;
            }
            if (iUser.checkUserNameExits(Username))
            {
                MessageBox.Show("User Name đã tồn tại trong hệ thống");
                return;
            }
            if (iUser.checkEmailExits(Email))
            {
                MessageBox.Show("Email đã tồn tại trong hệ thống");
                return;
            }
        }
        public RegisterViewModel()
        {

        }

    }
}
