using KeenVPN.Core;
using KeenVPN.Infrastructure;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KeenVPN.Presentation.ViewModels
{
    /// <summary>
    /// ViewModel for displaying and managing VPN node list.
    /// </summary>
    public class NodeListViewModel : INotifyPropertyChanged
    {
        private readonly IVpnService _vpnService;
        private ObservableCollection<VpnNode> _nodes = new();
        private string _errorMessage = string.Empty;
        private bool _isLoading;
        private VpnNode? _connectedNode;
        private ConnectionStatus _connectionStatus = ConnectionStatus.Disconnected;
        public ICommand ConnectCommand { get; }

        public ObservableCollection<VpnNode> Nodes
        {
            get => _nodes;
            set { _nodes = value; OnPropertyChanged(); }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(); }
        }

        public VpnNode? ConnectedNode
        {
            get => _connectedNode;
            set { _connectedNode = value; OnPropertyChanged(); OnPropertyChanged(nameof(ConnectButtonText)); }
        }

        public ConnectionStatus ConnectionStatus
        {
            get => _connectionStatus;
            set { _connectionStatus = value; OnPropertyChanged(); OnPropertyChanged(nameof(ConnectButtonText)); }
        }

        public string ConnectButtonText => "Disconnect";

        public NodeListViewModel(IVpnService vpnService)
        {
            _vpnService = vpnService;
            ConnectCommand = new RelayCommand(async node => await ConnectAsync(node as VpnNode), node => (node is VpnNode n) && n.CanConnect);
            LoadNodesAsync();
        }

        private async void LoadNodesAsync()
        {
            IsLoading = true;
            ErrorMessage = string.Empty;
            try
            {
                var nodes = await _vpnService.GetNodesAsync();
                Nodes = new ObservableCollection<VpnNode>(nodes);
            }
            catch
            {
                ErrorMessage = "Failed to load VPN nodes.";
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task ConnectAsync(VpnNode? node)
        {
            if (node == null) return;
            if (ConnectionStatus == ConnectionStatus.Connected && ConnectedNode == node)
            {
                // Disconnect logic
                ConnectionStatus = ConnectionStatus.Disconnected;
                ConnectedNode = null;
                SessionStore.CurrentSession = null;
                node.IsConnected = false;
                node.CanConnect = true;
                ShowNotification($"Disconnected from {node.Name}");
                UpdateNodeButtonStates();
                return;
            }
            ConnectionStatus = ConnectionStatus.Connecting;
            ErrorMessage = string.Empty;
            await Task.Delay(1000); // Simulate connection delay
            // Simulate random connection failure
            if (new System.Random().NextDouble() < 0.2) // 20% chance to fail
            {
                ConnectionStatus = ConnectionStatus.Disconnected;
                ErrorMessage = $"Failed to connect to {node.Name}. Please try again.";
                UpdateNodeButtonStates();
                return;
            }
            ConnectionStatus = ConnectionStatus.Connected;
            ConnectedNode = node;
            SessionStore.CurrentSession = new Session(SessionStore.CurrentSession?.User ?? new User("", ""), node, "Connected", System.DateTime.Now);
            node.IsConnected = true;
            node.CanConnect = true;
            ShowNotification($"Connected to {node.Name} ({node.Country})");
            UpdateNodeButtonStates();
        }

        private void UpdateNodeButtonStates()
        {
            foreach (var n in Nodes)
            {
                if (ConnectionStatus == ConnectionStatus.Connected && ConnectedNode == n)
                {
                    n.IsConnected = true;
                    n.CanConnect = true;
                }
                else
                {
                    n.IsConnected = false;
                    n.CanConnect = ConnectionStatus != ConnectionStatus.Connected;
                }
            }
        }

        private void ShowNotification(string message)
        {
            // Simple native notification (can be replaced with Windows toast)
            System.Windows.MessageBox.Show(message, "VPN Connection", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
