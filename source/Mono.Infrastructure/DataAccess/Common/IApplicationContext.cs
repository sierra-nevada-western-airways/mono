// <copyright file="IApplicationContext.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Mono.Domain.Common;

namespace Mono.Infrastructure.DataAccess.Common
{
    /// <summary>
    /// Interface for interacting with persistence.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IApplicationContext<in TEntity>
        where TEntity : class, IAggregateRoot
    {
        /// <summary>
        /// Adds an entity to the persistence.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="int"/> representing the number of rows affected.</returns>
        Task<int> AddEntity(TEntity entity, CancellationToken cancellationToken);
    }
}
