// <copyright file="User.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;

namespace Mono.Infrastructure.Authentication.Common.Models
{
    /// <summary>
    /// Represents the identity of a user for authentication.
    /// </summary>
    internal sealed class User : IdentityUser<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="userName">The user username.</param>
        /// <param name="email">The user email.</param>
        public User(string userName, string email)
            : this(Guid.NewGuid(), userName, email)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="id">The user identity.</param>
        /// <param name="userName">The user username.</param>
        /// <param name="email">The user email.</param>
        public User(Guid id, string userName, string email)
        {
            Id = id;
            UserName = userName;
            Email = email;
        }

        /// <summary>
        /// Gets the username for the user.
        /// </summary>
        public string UserNameValue => UserName ?? throw new ArgumentNullException(nameof(UserName));
    }
}
