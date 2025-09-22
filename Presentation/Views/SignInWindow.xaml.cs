using KeenVPN.Presentation.ViewModels;
using KeenVPN.Infrastructure;
using System.Windows;

namespace KeenVPN.Presentation.Views
{
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            InitializeComponent();
            DataContext = new AuthViewModel(new MockAuthService(), OnAuthenticated);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is AuthViewModel vm)
            {
                vm.Password = PasswordBox.Password;
            }
        }

        private void OnAuthenticated()
        {
            var nodeListWindow = new NodeListWindow();
            nodeListWindow.Show();
            this.Close();
        }
    }
}
