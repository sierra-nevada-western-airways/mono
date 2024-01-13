// <copyright file="ICustomerManager.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Mono.Infrastructure.Authentication.Common.Models;

namespace Mono.Infrastructure.Authentication.Common.Interfaces
{
    /// <summary>
    /// Allows for the management of identity customers.
    /// </summary>
    internal interface ICustomerManager
    {
        /// <summary>
        /// Creates a new customer and persists the result.
        /// </summary>
        /// <param name="customer">A <see cref="Customer"/>.</param>
        /// <param name="password">The customer's password.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IdentityResult"/>.</returns>
        Task<IdentityResult> CreateCustomer(Customer customer, string password);
    }
}
