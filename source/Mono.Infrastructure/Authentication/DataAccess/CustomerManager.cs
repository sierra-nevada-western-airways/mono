// <copyright file="CustomerManager.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Identity;
using Mono.Infrastructure.Authentication.Common.Events;
using Mono.Infrastructure.Authentication.Common.Interfaces;
using Mono.Infrastructure.Authentication.Common.Models;

namespace Mono.Infrastructure.Authentication.DataAccess
{
    /// <inheritdoc/>
    internal class CustomerManager : ICustomerManager
    {
        private readonly IPublisher _publisher;
        private readonly UserManager<Customer> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerManager"/> class.
        /// </summary>
        /// <param name="publisher">An instance of the <see cref="IPublisher"/> interface.</param>
        /// <param name="userManager">An instance of the <see cref="UserManager{TUser}"/> class.</param>
        public CustomerManager(IPublisher publisher, UserManager<Customer> userManager)
        {
            _publisher = publisher;
            _userManager = userManager;
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> CreateCustomer(Customer customer, string password, CancellationToken cancellationToken)
        {
            var result = await _userManager.CreateAsync(customer, password);

            if (result.Succeeded)
            {
                await _publisher.Publish(new CustomerCreated(), cancellationToken);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<Customer?> FindCustomerByUserName(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        /// <inheritdoc/>
        public async Task<bool> PasswordIsCorrect(Customer customer, string password)
        {
            return await _userManager.CheckPasswordAsync(customer, password);
        }
    }
}
