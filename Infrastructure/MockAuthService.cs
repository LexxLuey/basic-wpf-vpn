using KeenVPN.Core;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace KeenVPN.Infrastructure
{
    /// <summary>
    /// Mock authentication service using in-memory or local JSON data.
    /// </summary>
    public class MockAuthService : IAuthService
    {
        private readonly List<User> _users;

        public MockAuthService()
        {
            // Load users from local JSON file if exists, else use in-memory list
            var jsonPath = "users.json";
            if (File.Exists(jsonPath))
            {
                var json = File.ReadAllText(jsonPath);
                _users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
            else
            {
                _users = new List<User>
                {
                    new User("test@example.com", "password123"),
                    new User("user@vpn.com", "vpnpass")
                };
            }
        }

        public async Task<User?> AuthenticateAsync(string email, string password)
        {
            // Simulate async operation
            await Task.Delay(100);
            return _users.Find(u => u.Email == email && u.Password == password);
        }
    }
}
