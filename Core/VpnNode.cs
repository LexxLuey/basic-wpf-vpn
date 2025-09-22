using System;
using System.ComponentModel;

namespace KeenVPN.Core
{
    /// <summary>
    /// Represents a VPN node available for connection.
    /// </summary>
    public class VpnNode : INotifyPropertyChanged
    {
        /// <summary>
        /// Node name.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Country where the node is located.
        /// </summary>
        public string Country { get; init; }

        /// <summary>
        /// Latency in milliseconds.
        /// </summary>
        public int LatencyMs { get; init; }

        /// <summary>
        /// Public key for the node.
        /// </summary>
        public string PublicKey { get; init; }

        /// <summary>
        /// Endpoint IP address.
        /// </summary>
        public string EndpointIp { get; init; }

        private bool _isConnected;
        /// <summary>
        /// Indicates if the node is currently connected.
        /// </summary>
        public bool IsConnected
        {
            get => _isConnected;
            set { _isConnected = value; OnPropertyChanged(nameof(IsConnected)); }
        }

        private bool _canConnect = true;
        /// <summary>
        /// Indicates if the node can be connected to.
        /// </summary>
        public bool CanConnect
        {
            get => _canConnect;
            set { _canConnect = value; OnPropertyChanged(nameof(CanConnect)); }
        }

        /// <summary>
        /// Creates a new VpnNode instance.
        /// </summary>
        public VpnNode(string name, string country, int latencyMs, string publicKey, string endpointIp)
        {
            Name = name;
            Country = country;
            LatencyMs = latencyMs;
            PublicKey = publicKey;
            EndpointIp = endpointIp;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
