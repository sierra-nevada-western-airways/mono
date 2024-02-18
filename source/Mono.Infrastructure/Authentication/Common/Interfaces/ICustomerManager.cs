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
    public interface ICustomerManager
    {
        /// <summary>
        /// Creates a new user and persists the result.
        /// </summary>
        /// <param name="user">A <see cref="User"/>.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IdentityResult"/>.</returns>
        Task<IdentityResult> CreateCustomer(User user, string password, CancellationToken cancellationToken);

        /// <summary>
        /// Finds a user by username.
        /// </summary>
        /// <param name="userName">The user username.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="User"/>.</returns>
        Task<User?> FindCustomerByUserName(string userName);

        /// <summary>
        /// Checks a password for a user.
        /// </summary>
        /// <param name="user">A <see cref="User"/>.</param>
        /// <param name="password">The password for the user.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="bool"/>.</returns>
        Task<bool> PasswordIsCorrect(User user, string password);
    }
}
