// <copyright file="GlobalExceptionHandler.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Mono.Infrastructure.Exceptions
{
    /// <summary>
    /// Handler for global exceptions.
    /// </summary>
    public class GlobalExceptionHandler : INotificationHandler<GlobalExceptionOccurred>
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalExceptionHandler"/> class.
        /// </summary>
        /// <param name="logger">An instance of the <see cref="ILogger{TCategoryName}"/> interface.</param>
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handles a global exception.
        /// </summary>
        /// <param name="notification">A <see cref="GlobalExceptionOccurred"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task Handle(GlobalExceptionOccurred notification, CancellationToken cancellationToken)
        {
            _logger.LogError("A global exception of type {exception} occurred at {timestamp}.", notification.Exception, notification.DateTime);

            return Task.CompletedTask;
        }
    }
}
