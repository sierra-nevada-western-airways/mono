// <copyright file="Customer.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;

namespace Mono.Infrastructure.Authentication.Common.Models
{
    /// <summary>
    /// Represents the identity of a customer for authentication.
    /// </summary>
    internal class Customer : IdentityUser<Guid>
    {
        /// <summary>
        /// Gets the username for the customer.
        /// </summary>
        public string UserNameValue => UserName ?? throw new ArgumentNullException(nameof(UserName));
    }
}
