// <copyright file="UserRepository.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Identity;
using Mono.Infrastructure.Authentication.Common.Interfaces;
using Mono.Infrastructure.Authentication.Common.Models;

namespace Mono.Infrastructure.Authentication.DataAccess
{
    /// <inheritdoc/>
    internal class UserRepository : IUserRepository
    {
        private readonly IPublisher _publisher;
        private readonly IUserManager _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="publisher">An instance of the <see cref="IPublisher"/> interface.</param>
        /// <param name="userManager">An instance of the <see cref="UserManager{TUser}"/> class.</param>
        public UserRepository(IPublisher publisher, IUserManager userManager)
        {
            _publisher = publisher;
            _userManager = userManager;
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> CreateUser(User user, string password, CancellationToken cancellationToken)
        {
            var result = await _userManager.CreateUser(user, password);

            if (result.Succeeded)
            {
                await PublishEvents(user.DomainEvents, cancellationToken);
            }

            return result;
        }

        private async Task PublishEvents(IEnumerable<INotification> domainEvents, CancellationToken cancellationToken)
        {
            foreach (var notification in domainEvents)
            {
                await _publisher.Publish(notification, cancellationToken);
            }
        }
    }
}
