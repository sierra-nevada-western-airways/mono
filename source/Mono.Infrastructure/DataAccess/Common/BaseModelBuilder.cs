// <copyright file="BaseModelBuilder.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Mono.Domain.Common;

namespace Mono.Infrastructure.DataAccess.Common
{
    /// <summary>
    /// Base model builder for entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class BaseModelBuilder<TEntity>
        where TEntity : class, IAggregateRoot
    {
        /// <summary>
        /// Configures the base entity.
        /// </summary>
        /// <param name="builder">An instance of the <see cref="ModelBuilder"/> object.</param>
        public virtual void BuildEntity(ModelBuilder builder)
        {
            builder.Entity<TEntity>(options =>
            {
                options.HasKey(entity => entity.Id);
            });
        }
    }
}
