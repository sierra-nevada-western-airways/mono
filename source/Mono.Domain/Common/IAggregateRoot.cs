// <copyright file="IAggregateRoot.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatR;

namespace Mono.Domain.Common
{
    /// <summary>
    /// Designates an entity is an aggregate root.
    /// </summary>
    public interface IAggregateRoot : IEntity
    {
        /// <summary>
        /// Gets the domain events.
        /// </summary>
        public IEnumerable<INotification> DomainEvents { get; }
    }
}
