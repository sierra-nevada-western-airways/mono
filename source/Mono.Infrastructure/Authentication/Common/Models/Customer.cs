// <copyright file="Customer.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;

namespace Mono.Infrastructure.Authentication.Common.Models
{
    /// <summary>
    /// Represents the identity of a customer for authentication.
    /// </summary>
    internal sealed class Customer : IdentityUser<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="userName">The customer username.</param>
        /// <param name="email">The customer email.</param>
        public Customer(string userName, string email)
            : this(Guid.NewGuid(), userName, email)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="id">The customer identity.</param>
        /// <param name="userName">The customer username.</param>
        /// <param name="email">The customer email.</param>
        public Customer(Guid id, string userName, string email)
        {
            Id = id;
            UserName = userName;
            Email = email;
        }

        /// <summary>
        /// Gets the username for the customer.
        /// </summary>
        public string UserNameValue => UserName ?? throw new ArgumentNullException(nameof(UserName));
    }
}
