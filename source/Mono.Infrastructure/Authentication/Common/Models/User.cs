// <copyright file="User.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Mono.Infrastructure.Authentication.CreateUser;

namespace Mono.Infrastructure.Authentication.Common.Models
{
    /// <summary>
    /// Represents the identity of a user for authentication.
    /// </summary>
    public sealed class User : IdentityUser<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            new UserValidator().ValidateAndThrow(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="userName">The user username.</param>
        /// <param name="email">The user email.</param>
        public User(string userName, string email)
            : this()
        {
            Id = Guid.NewGuid();
            UserName = userName;
            Email = email;

            new UserValidator().ValidateAndThrow(this);
        }

        /// <summary>
        /// Gets the username for the user.
        /// </summary>
        public string UserNameValue => UserName ?? throw new ArgumentNullException(nameof(UserName));
    }
}
