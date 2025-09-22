using KeenVPN.Core;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace KeenVPN.Infrastructure
{
    /// <summary>
    /// Mock VPN service using in-memory or local JSON data.
    /// </summary>
    public class MockVpnService : IVpnService
    {
        private readonly List<VpnNode> _nodes;

        public MockVpnService()
        {
            var jsonPath = "nodes.json";
            if (File.Exists(jsonPath))
            {
                var json = File.ReadAllText(jsonPath);
                _nodes = JsonSerializer.Deserialize<List<VpnNode>>(json) ?? new List<VpnNode>();
            }
            else
            {
                _nodes = new List<VpnNode>
                {
                    new VpnNode("London Node", "UK", 42, "pubkey1", "51.140.12.34"),
                    new VpnNode("New York Node", "USA", 85, "pubkey2", "104.131.23.45"),
                    new VpnNode("Berlin Node", "Germany", 60, "pubkey3", "85.214.132.117")
                };
            }
        }

        public async Task<List<VpnNode>> GetNodesAsync()
        {
            await Task.Delay(100);
            return _nodes;
        }
    }
}
