using CommunityToolkit.Mvvm.ComponentModel;

namespace WPF.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string username;
        [ObservableProperty]
        private string password;
    }
}
