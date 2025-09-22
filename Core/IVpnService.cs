using System.Collections.Generic;
using System.Threading.Tasks;

namespace KeenVPN.Core
{
    /// <summary>
    /// VPN node discovery service abstraction.
    /// </summary>
    public interface IVpnService
    {
        /// <summary>
        /// Fetches the list of available VPN nodes.
        /// </summary>
        /// <returns>List of VPN nodes</returns>
        Task<List<VpnNode>> GetNodesAsync();
    }
}
