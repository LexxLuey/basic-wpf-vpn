using KeenVPN.Core;
using System.Threading.Tasks;

namespace KeenVPN.Core
{
    /// <summary>
    /// Authentication service abstraction.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Authenticates a user by email and password.
        /// </summary>
        /// <param name="email">User email</param>
        /// <param name="password">User password</param>
        /// <returns>Authenticated User or null</returns>
        Task<User?> AuthenticateAsync(string email, string password);
    }
}
