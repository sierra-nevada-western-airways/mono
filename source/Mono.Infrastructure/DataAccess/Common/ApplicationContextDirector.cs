// <copyright file="ApplicationContextDirector.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace Mono.Infrastructure.DataAccess.Common
{
    /// <inheritdoc />
    internal class ApplicationContextDirector<TEntity> : IApplicationContext<TEntity>
        where TEntity : class, IAggregateRoot
    {
        private readonly ApplicationContext _applicationContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContextDirector{TEntity}"/> class.
        /// </summary>
        /// <param name="applicationContext">An instance of the <see cref="ApplicationContext"/> class.</param>
        public ApplicationContextDirector(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        /// <inheritdoc/>
        public async Task<int> AddEntity(TEntity entity, CancellationToken cancellationToken)
        {
            await _applicationContext.Set<TEntity>().AddAsync(entity, cancellationToken);

            return await _applicationContext.SaveChangesAsync(cancellationToken);
        }
    }
}
