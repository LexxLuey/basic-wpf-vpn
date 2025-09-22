using System;

namespace KeenVPN.Core
{
    /// <summary>
    /// Represents a user session with connection details.
    /// </summary>
    public class Session
    {
        /// <summary>
        /// The authenticated user.
        /// </summary>
        public User User { get; init; }

        /// <summary>
        /// The connected VPN node.
        /// </summary>
        public VpnNode ConnectedNode { get; init; }

        /// <summary>
        /// Connection status (e.g., Connected, Disconnected).
        /// </summary>
        public string ConnectionStatus { get; set; }

        /// <summary>
        /// Session start time.
        /// </summary>
        public DateTime StartTime { get; init; }

        /// <summary>
        /// Creates a new Session instance.
        /// </summary>
        public Session(User user, VpnNode connectedNode, string connectionStatus, DateTime startTime)
        {
            User = user;
            ConnectedNode = connectedNode;
            ConnectionStatus = connectionStatus;
            StartTime = startTime;
        }
    }
}
