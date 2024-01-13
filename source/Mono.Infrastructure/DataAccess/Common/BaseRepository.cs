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
        where TEntity : IAggregateRoot
    {
        private readonly IPublisher _publisher;
        private readonly ApplicationContext _applicationContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="publisher">An instance of the <see cref="IPublisher"/> interface.</param>
        /// <param name="applicationContext">An instance of the <see cref="ApplicationContext"/> interface.</param>
        protected BaseRepository(IPublisher publisher, ApplicationContext applicationContext)
        {
            _publisher = publisher;
            _applicationContext = applicationContext;
        }

        /// <inheritdoc/>
        public async Task<Result> CreateEntity(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _applicationContext.AddAsync(entity, cancellationToken);

            var rowCount = await _applicationContext.SaveChangesAsync(cancellationToken);

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
                await _publisher.Publish(domainEvent, cancellationToken);
            }
        }
    }
}
