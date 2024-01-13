// <copyright file="Entity.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

namespace Mono.Domain.Common
{
    /// <summary>
    /// Base entity class.
    /// </summary>
    public abstract class Entity : IEntity, IEquatable<Entity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        protected Entity()
            : this(Guid.NewGuid())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        /// <param name="id">The id of the entity.</param>
        protected Entity(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Id = id;
        }

        /// <inheritdoc/>
        public Guid Id { get; }

        /// <summary>
        /// Determines equality for a different entity.
        /// </summary>
        /// <param name="other">The other entity to compare.</param>
        /// <returns>A bool if the objects are equal.</returns>
        public bool Equals(Entity? other)
        {
            if (other == null)
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        /// <summary>
        /// Determines equality for a different object.
        /// </summary>
        /// <param name="obj">The other object to compare.</param>
        /// <returns>A bool if the object are equal.
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (obj is Entity entity)
            {
                return Equals(entity);
            }

            return false;
        }

        /// <summary>
        /// Returns a hash code for the entity.
        /// </summary>
        /// <returns>A hash code for the entity.</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
