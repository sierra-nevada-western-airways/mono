// <copyright file="UserNameSignInResponse.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Mono.Infrastructure.Authentication.Common.Responses;

namespace Mono.Infrastructure.Authentication.UserNameSignIn
{
    /// <summary>
    /// Response object for a <see cref="UserNameSignInRequest"/>.
    /// </summary>
    public class UserNameSignInResponse : TokenResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserNameSignInResponse"/> class.
        /// </summary>
        /// <param name="bearerToken">The bearer token.</param>
        /// <param name="refreshToken">The refresh token.</param>
        public UserNameSignInResponse(string bearerToken, string refreshToken)
            : base(bearerToken, refreshToken)
        {
        }
    }
}
