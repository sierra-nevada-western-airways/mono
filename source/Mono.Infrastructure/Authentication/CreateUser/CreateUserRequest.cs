// <copyright file="CreateUserRequest.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using MediatorBuddy;

namespace Mono.Infrastructure.Authentication.CreateUser
{
    /// <summary>
    /// Request class for creating a new user.
    /// </summary>
    public class CreateUserRequest : IEnvelopeRequest<CreateUserResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserRequest"/> class.
        /// </summary>
        /// <param name="userName">The user username.</param>
        /// <param name="password">The user password.</param>
        /// <param name="email">The user email.</param>
        public CreateUserRequest(string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
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

        /// <summary>
        /// Gets the user email.
        /// </summary>
        [EmailAddress]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; }
    }
}
