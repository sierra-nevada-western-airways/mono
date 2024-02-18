// <copyright file="RefreshToken.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

namespace Mono.Infrastructure.Authentication.Common.Models
{
    /// <summary>
    /// Represents a refresh token for semi-session authentication.
    /// </summary>
    public class RefreshToken
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RefreshToken"/> class.
        /// </summary>
        /// <param name="token">A new refresh token.</param>
        /// <param name="expiresAt">The token expiration timestamp.</param>
        public RefreshToken(string token, DateTime expiresAt)
        {
            Token = token;
            ExpiresAt = expiresAt;
            User = default!;
        }

        private RefreshToken(string token, User user)
            : this(token, DateTime.UtcNow.AddMinutes(15))
        {
            User = user;
        }

        /// <summary>
        /// Gets the refresh token.
        /// </summary>
        public string Token { get; }

        /// <summary>
        /// Gets the expiration for the token.
        /// </summary>
        public DateTime ExpiresAt { get; }

        /// <summary>
        /// Gets the user for the token.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Factory method for creating a new refresh token.
        /// </summary>
        /// <param name="token">A new refresh token.</param>
        /// <param name="user">A <see cref="User"/>.</param>
        /// <returns>A new <see cref="RefreshToken"/> instance.</returns>
        public static RefreshToken Instantiate(string token, User user)
        {
            return new RefreshToken(token, user);
        }
    }
}
