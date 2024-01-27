// <copyright file="AggregateRoot.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatR;

namespace Mono.Domain.Common
{
    /// <summary>
    /// Designates an entity as an aggregate root.
    /// </summary>
    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
        private readonly List<INotification> _domainEvents;

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
        /// </summary>
        protected AggregateRoot()
        {
            _domainEvents = new List<INotification>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
        /// </summary>
        /// <param name="id">The entities identifier.</param>
        protected AggregateRoot(Guid id)
            : base(id)
        {
            _domainEvents = new List<INotification>();
        }

        /// <inheritdoc />
        public IEnumerable<INotification> DomainEvents => _domainEvents;

        /// <summary>
        /// Appends a domain events to the existing list.
        /// </summary>
        /// <param name="notification">A <see cref="INotification"/> to append.</param>
        public void AddNotification(INotification notification)
        {
            _domainEvents.Add(notification);
        }
    }
}
