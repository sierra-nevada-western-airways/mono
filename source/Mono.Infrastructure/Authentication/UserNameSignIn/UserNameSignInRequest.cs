// <copyright file="UserNameSignInRequest.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using MediatorBuddy;

namespace Mono.Infrastructure.Authentication.UserNameSignIn
{
    /// <summary>
    /// Request object for a username sign in.
    /// </summary>
    public class UserNameSignInRequest : IEnvelopeRequest<UserNameSignInResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserNameSignInRequest"/> class.
        /// </summary>
        /// <param name="userName">The user username.</param>
        /// <param name="password">The user password.</param>
        public UserNameSignInRequest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        /// <summary>
        /// Gets the user username.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; }

        /// <summary>
        /// Gets the user password.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Password { get; }
    }
}
