// <copyright file="ITokenService.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Mono.Infrastructure.Authentication.Common.Models;

namespace Mono.Infrastructure.Authentication.Common.Interfaces
{
    /// <summary>
    /// Manages tokens for a customer.
    /// </summary>
    internal interface ITokenService
    {
        /// <summary>
        /// Generates a bearer token for a customer.
        /// </summary>
        /// <param name="claims">A <see cref="IEnumerable{T}"/> of <see cref="Claim"/>.</param>
        /// <returns>A <see cref="string"/> bearer token.</returns>
        string GenerateToken(IEnumerable<Claim> claims);

        /// <summary>
        /// Generates a refresh token for a <see cref="Customer"/>.
        /// </summary>
        /// <param name="customer">The <see cref="Customer"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IdentityResult"/>.</returns>
        Task<string> GenerateRefreshToken(Customer customer, CancellationToken cancellationToken);

        /// <summary>
        /// Clears all token for a <see cref="Customer"/>.
        /// </summary>
        /// <param name="customer">The <see cref="Customer"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IdentityResult"/>.</returns>
        Task<IdentityResult> ClearTokens(Customer customer, CancellationToken cancellationToken);
    }
}
