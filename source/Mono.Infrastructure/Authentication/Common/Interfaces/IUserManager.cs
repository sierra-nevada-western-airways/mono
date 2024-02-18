// <copyright file="IUserManager.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Mono.Infrastructure.Authentication.Common.Models;

namespace Mono.Infrastructure.Authentication.Common.Interfaces
{
    /// <summary>
    /// Allows for the management of identity customers.
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Creates a new user and persists the result.
        /// </summary>
        /// <param name="user">A <see cref="User"/>.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IdentityResult"/>.</returns>
        Task<IdentityResult> CreateUser(User user, string password);

        /// <summary>
        /// Attempts to looker a <see cref="User"/> by its name.
        /// </summary>
        /// <param name="userName">The name of the <see cref="User"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="User"/>.</returns>
        Task<User?> FindUserByName(string userName);

        /// <summary>
        /// Checks if a password matches a <see cref="User"/>.
        /// </summary>
        /// <param name="user">The <see cref="User"/> to check.</param>
        /// <param name="password">The password for the <see cref="User"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="bool"/>.</returns>
        Task<bool> PasswordIsCorrect(User user, string password);

        /// <summary>
        /// Removes a <see cref="User"/> from the store.
        /// </summary>
        /// <param name="user">The <see cref="User"/> to remove.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IdentityResult"/> representing the asynchronous operation.</returns>
        Task<IdentityResult> DeleteUser(User user);
    }
}
