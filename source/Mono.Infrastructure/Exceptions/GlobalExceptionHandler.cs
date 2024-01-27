// <copyright file="GlobalExceptionHandler.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using MediatR;

namespace Mono.Infrastructure.Exceptions
{
    /// <summary>
    /// Handler for global exceptions.
    /// </summary>
    public class GlobalExceptionHandler : INotificationHandler<GlobalExceptionOccurred>
    {
        /// <summary>
        /// Handles a global exception.
        /// </summary>
        /// <param name="notification">A <see cref="GlobalExceptionOccurred"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task Handle(GlobalExceptionOccurred notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
