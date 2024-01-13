// <copyright file="CustomerManager.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Mono.Infrastructure.Authentication.Common.Interfaces;
using Mono.Infrastructure.Authentication.Common.Models;

namespace Mono.Infrastructure.Authentication.DataAccess
{
    /// <inheritdoc/>
    internal class CustomerManager : ICustomerManager
    {
        private readonly UserManager<Customer> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerManager"/> class.
        /// </summary>
        /// <param name="userManager">An instance of the <see cref="UserManager{TUser}"/> class.</param>
        public CustomerManager(UserManager<Customer> userManager)
        {
            _userManager = userManager;
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> CreateCustomer(Customer customer, string password)
        {
            return await _userManager.CreateAsync(customer, password);
        }
    }
}
