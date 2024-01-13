// <copyright file="CustomerCreated.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatR;

namespace Mono.Application.Customers.CreateCustomer
{
    /// <summary>
    /// Event when a user has been created.
    /// </summary>
    public class CustomerCreated : INotification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCreated"/> class.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        public CustomerCreated(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        public Guid Id { get; }
    }
}
