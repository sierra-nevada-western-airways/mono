// <copyright file="UserDirector.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Mono.Infrastructure.Authentication.Common.Interfaces;
using Mono.Infrastructure.Authentication.Common.Models;

namespace Mono.Infrastructure.Authentication.DataAccess
{
    /// <inheritdoc />
    internal class UserDirector : IUserManager
    {
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDirector"/> class.
        /// </summary>
        /// <param name="userManager">An instance of the <see cref="UserManager{TUser}"/> object.</param>
        public UserDirector(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> CreateUser(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        /// <inheritdoc/>
        public async Task<User?> FindUserByName(string userName)
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
