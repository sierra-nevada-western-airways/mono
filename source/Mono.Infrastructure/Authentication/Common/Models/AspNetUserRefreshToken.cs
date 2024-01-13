// <copyright file="AspNetUserRefreshToken.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Mono.Infrastructure.Authentication.Common.Models;

namespace Mono.Infrastructure.Authentication.Common
{
    /// <summary>
    /// Represents a refresh token for semi-session authentication.
    /// </summary>
    internal class AspNetUserRefreshToken
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AspNetUserRefreshToken"/> class.
        /// </summary>
        /// <param name="token">A new refresh token.</param>
        /// <param name="expiresAt">The token expiration timestamp.</param>
        public AspNetUserRefreshToken(string token, DateTime expiresAt)
        {
            Token = token;
            ExpiresAt = expiresAt;
            Customer = default!;
        }

        private AspNetUserRefreshToken(string token, Customer customer)
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
    }
}
