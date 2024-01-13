// <copyright file="CustomerManager.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Identity;
using Mono.Application.Customers.CreateCustomer;
using Mono.Infrastructure.Authentication.Common.Interfaces;
using Mono.Infrastructure.Authentication.Common.Models;

namespace Mono.Infrastructure.Authentication.DataAccess
{
    /// <inheritdoc/>
    internal class CustomerManager : ICustomerManager
    {
        private readonly IPublisher _publisher;
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerManager"/> class.
        /// </summary>
        /// <param name="publisher">An instance of the <see cref="IPublisher"/> interface.</param>
        /// <param name="userManager">An instance of the <see cref="UserManager{TUser}"/> class.</param>
        public CustomerManager(IPublisher publisher, UserManager<User> userManager)
        {
            _publisher = publisher;
            _userManager = userManager;
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> CreateCustomer(User user, string password, CancellationToken cancellationToken)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _publisher.Publish(new CustomerCreated(user.Id), cancellationToken);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<User?> FindCustomerByUserName(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        /// <inheritdoc/>
        public async Task<bool> PasswordIsCorrect(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}
