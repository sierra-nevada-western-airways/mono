// <copyright file="UserNameSignInRequest.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Mono.Infrastructure.Authentication.UserNameSignIn
{
    /// <summary>
    /// Request object for a username sign in.
    /// </summary>
    public class UserNameSignInRequest : IRequest<UserNameSignInResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserNameSignInRequest"/> class.
        /// </summary>
        /// <param name="userName">The customer username.</param>
        /// <param name="password">The customer password.</param>
        public UserNameSignInRequest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        /// <summary>
        /// Gets the customer username.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; }

        /// <summary>
        /// Gets the customer password.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Password { get; }
    }
}
