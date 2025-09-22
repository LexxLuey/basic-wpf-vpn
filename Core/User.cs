using System;

namespace KeenVPN.Core
{
    /// <summary>
    /// Represents a user for authentication purposes.
    /// </summary>
    public class User
    {
        /// <summary>
        /// User's email address.
        /// </summary>
        public string Email { get; init; }

        /// <summary>
        /// User's password (mocked).
        /// </summary>
        public string Password { get; init; }

        /// <summary>
        /// Creates a new User instance.
        /// </summary>
        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
