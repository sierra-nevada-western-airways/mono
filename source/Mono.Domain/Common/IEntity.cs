// <copyright file="IEntity.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

namespace Mono.Domain.Common
{
    /// <summary>
    /// Basic interface for entities.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets the entity identifier.
        /// </summary>
        Guid Id { get; }
    }
}
