// <copyright file="TokenResponse.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Mono.Infrastructure.Authentication.Common.Responses
{
    /// <summary>
    /// Base response that contains tokens.
    /// </summary>
    public abstract class TokenResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenResponse"/> class.
        /// </summary>
        /// <param name="bearerToken">The bearer token.</param>
        /// <param name="refreshToken">The refresh token.</param>
        protected TokenResponse(string bearerToken, string refreshToken)
        {
            BearerToken = bearerToken;
            RefreshToken = refreshToken;
        }

        /// <summary>
        /// Gets the bearer token.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string BearerToken { get; }

        /// <summary>
        /// Gets the refresh token.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string RefreshToken { get; }
    }
}
