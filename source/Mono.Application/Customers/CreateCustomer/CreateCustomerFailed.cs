// <copyright file="CreateCustomerFailed.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatR;

namespace Mono.Application.Customers.CreateCustomer
{
    /// <summary>
    /// Event for a failed customer creation.
    /// </summary>
    public class CreateCustomerFailed : INotification
    {
        private CreateCustomerFailed(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Initializes the <see cref="CreateCustomerFailed"/> event.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <returns>A new instance of the <see cref="CreateCustomerFailed"/> class.</returns>
        public static CreateCustomerFailed Initialize(Guid id)
        {
            return new CreateCustomerFailed(id);
        }
    }
}
