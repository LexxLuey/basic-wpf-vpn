using KeenVPN.Core;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KeenVPN.Presentation.ViewModels
{
    public class AuthViewModel : INotifyPropertyChanged
    {
        private string _email = string.Empty;
        private string _password = string.Empty;
        private string _errorMessage = string.Empty;
        private bool _isAuthenticated;
        private readonly IAuthService _authService;
        private readonly System.Action? _onAuthenticated;

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); CommandManager.InvalidateRequerySuggested(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); CommandManager.InvalidateRequerySuggested(); }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public bool IsAuthenticated
        {
            get => _isAuthenticated;
            set { _isAuthenticated = value; OnPropertyChanged(); }
        }

        public ICommand SignInCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public AuthViewModel(IAuthService authService, System.Action? onAuthenticated = null)
        {
            _authService = authService;
            _onAuthenticated = onAuthenticated;
            SignInCommand = new RelayCommand(async _ => await SignInAsync(), _ => CanSignIn());
        }

        private bool CanSignIn() => !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);

        private async Task SignInAsync()
        {
            ErrorMessage = string.Empty;
            var user = await _authService.AuthenticateAsync(Email, Password);
            if (user != null)
            {
                IsAuthenticated = true;
                _onAuthenticated?.Invoke();
            }
            else
            {
                ErrorMessage = "Invalid email or password.";
                IsAuthenticated = false;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
