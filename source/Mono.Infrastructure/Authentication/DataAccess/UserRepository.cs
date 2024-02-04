// <copyright file="UserRepository.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Mono.Infrastructure.Authentication.Common.Interfaces;
using Mono.Infrastructure.Authentication.Common.Models;

namespace Mono.Infrastructure.Authentication.DataAccess
{
    /// <inheritdoc/>
    internal class UserRepository : IUserRepository
    {
        private readonly IUserManager _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="userManager">An instance of the <see cref="UserManager{TUser}"/> class.</param>
        public UserRepository(IUserManager userManager)
        {
            _userManager = userManager;
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> CreateUser(User user, string password, CancellationToken cancellationToken)
        {
           return await _userManager.CreateUser(user, password);
        }
    }
}
