// <copyright file="RefreshToken.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

namespace Mono.Infrastructure.Authentication.Common.Models
{
    /// <summary>
    /// Represents a refresh token for semi-session authentication.
    /// </summary>
    internal class RefreshToken
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
            Customer = default!;
        }

        private RefreshToken(string token, Customer customer)
            : this(token, DateTime.UtcNow.AddMinutes(15))
        {
            Customer = customer;
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
        /// Gets the customer for the token.
        /// </summary>
        public Customer Customer { get; }

        /// <summary>
        /// Factory method for creating a new refresh token.
        /// </summary>
        /// <param name="token">A new refresh token.</param>
        /// <param name="customer">A <see cref="Customer"/>.</param>
        /// <returns>A new <see cref="RefreshToken"/> instance.</returns>
        public static RefreshToken Instantiate(string token, Customer customer)
        {
            return new RefreshToken(token, customer);
        }
    }
}
