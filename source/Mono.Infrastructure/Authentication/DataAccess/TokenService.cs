// <copyright file="TokenService.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Mono.Infrastructure.Authentication.Common.Interfaces;
using Mono.Infrastructure.Authentication.Common.Models;

namespace Mono.Infrastructure.Authentication.DataAccess
{
    /// <inheritdoc />
    internal class TokenService : ITokenService
    {
        private readonly SecurityOptions _securityOptions;
        private readonly CustomerContext _customerContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenService"/> class.
        /// </summary>
        /// <param name="securityOptions">An instance of the <see cref="SecurityOptions"/> class.</param>
        /// <param name="customerContext">An instance of the <see cref="CustomerContext"/> class.</param>
        public TokenService(SecurityOptions securityOptions, CustomerContext customerContext)
        {
            _securityOptions = securityOptions;
            _customerContext = customerContext;
        }

        /// <inheritdoc/>
        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityOptions.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                _securityOptions.Issuer,
                _securityOptions.Audience,
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(30),
                credentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        /// <inheritdoc/>
        public async Task<string> GenerateRefreshToken(Customer customer, CancellationToken cancellationToken)
        {
            string refreshToken;

            using (var generator = RandomNumberGenerator.Create())
            {
                var bytes = new byte[64];
                generator.GetBytes(bytes);
                refreshToken = Convert.ToBase64String(bytes);
            }

            await _customerContext.RefreshTokens.AddAsync(RefreshToken.Instantiate(refreshToken, customer), cancellationToken);

            await _customerContext.SaveChangesAsync(cancellationToken);

            return refreshToken;
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> ClearTokens(Customer customer, CancellationToken cancellationToken)
        {
            var refreshTokens = await _customerContext.RefreshTokens
                .Where(token => token.Customer.Id == customer.Id)
                .ToListAsync(cancellationToken);

            _customerContext.RefreshTokens.RemoveRange(refreshTokens);

            var result = await _customerContext.SaveChangesAsync(cancellationToken);

            if (result > 0)
            {
                return IdentityResult.Success;
            }

            return IdentityResult.Failed();
        }
    }
}
