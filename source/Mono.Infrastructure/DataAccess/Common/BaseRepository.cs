// <copyright file="BaseRepository.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatR;
using Mono.Application.Common.DataAccess;
using Mono.Application.Common.Responses;
using Mono.Domain.Common;

namespace Mono.Infrastructure.DataAccess.Common
{
    /// <summary>
    /// Designates a base repository to reuse.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class BaseRepository<TEntity>
        : ICreateEntity<TEntity>
        where TEntity : class, IAggregateRoot
    {
        private readonly IApplicationContext<TEntity> _applicationContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="publisher">An instance of the <see cref="IPublisher"/> interface.</param>
        /// <param name="applicationContext">An instance of the <see cref="ApplicationContext"/> interface.</param>
        protected BaseRepository(IPublisher publisher, IApplicationContext<TEntity> applicationContext)
        {
            Publisher = publisher;
            _applicationContext = applicationContext;
        }

        /// <summary>
        /// Gets the <see cref="IPublisher"/> instance.
        /// </summary>
        protected IPublisher Publisher { get; }

        /// <inheritdoc/>
        public virtual async Task<Result> CreateEntity(TEntity entity, CancellationToken cancellationToken = default)
        {
            int rowCount;

            try
            {
                rowCount = await _applicationContext.AddEntity(entity, cancellationToken);
            }
            catch (Exception)
            {
                return Result.Failure();
            }

            if (rowCount > 0)
            {
                await PublishEvents(entity, cancellationToken);

                return Result.Success();
            }

            return Result.Failure();
        }

        private async Task PublishEvents(IAggregateRoot aggregateRoot, CancellationToken cancellationToken)
        {
            foreach (var domainEvent in aggregateRoot.DomainEvents)
            {
                await Publisher.Publish(domainEvent, cancellationToken);
            }
        }
    }
}
