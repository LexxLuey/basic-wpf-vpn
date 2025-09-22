using KeenVPN.Core;

namespace KeenVPN.Infrastructure
{
    /// <summary>
    /// Stores the current session (user and connected node) in memory.
    /// </summary>
    public static class SessionStore
    {
        public static Session? CurrentSession { get; set; }
    }
}
