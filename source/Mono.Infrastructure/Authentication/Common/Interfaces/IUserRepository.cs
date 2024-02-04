// <copyright file="IUserRepository.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Mono.Infrastructure.Authentication.Common.Models;

namespace Mono.Infrastructure.Authentication.Common.Interfaces
{
    /// <summary>
    /// Allows interaction with user persistence.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Creates a new <see cref="User"/> in the persistence.
        /// </summary>
        /// <param name="user">The <see cref="User"/> to persist.</param>
        /// <param name="password">The password for the <see cref="User"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IdentityResult"/>.</returns>
        Task<IdentityResult> CreateUser(User user, string password, CancellationToken cancellationToken);
    }
}
