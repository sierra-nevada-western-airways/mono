// <copyright file="ICreateEntity.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Mono.Application.Common.Responses;

namespace Mono.Application.Common.DataAccess
{
    /// <summary>
    /// Designates an entity can be created.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface ICreateEntity<in TEntity>
    {
        /// <summary>
        /// Adds a newly created entity to persistence.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="Result"/> designating the rows affected.</returns>
        Task<Result> CreateEntity(TEntity entity, CancellationToken cancellationToken);
    }
}
