// <copyright file="IApplicationContext.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;

namespace Mono.Infrastructure.DataAccess.Common
{
    /// <summary>
    /// Interface for persistence context to allow for testing.
    /// </summary>
    public interface IApplicationContext
    {
        /// <summary>
        /// Gets the db set for the entity type.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>A <see cref="DbSet{TEntity}"/>.</returns>
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        /// <summary>
        /// Saves all changes to the persistence method.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="int"/> representing the row change count.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
