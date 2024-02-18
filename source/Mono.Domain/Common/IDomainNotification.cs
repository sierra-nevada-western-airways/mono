// <copyright file="IDomainNotification.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using MediatR;

namespace Mono.Domain.Common
{
    /// <summary>
    /// Interface constraint for domain event publishing.
    /// </summary>
    public interface IDomainNotification : IDomainEvent, INotification
    {
    }
}
