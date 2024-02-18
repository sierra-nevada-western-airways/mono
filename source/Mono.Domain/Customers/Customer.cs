// <copyright file="Customer.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace Mono.Domain.Customers
{
    /// <summary>
    /// Entity for representing a customer.
    /// </summary>
    public class Customer : AggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        public Customer(Guid id)
            : base(id)
        {
        }
    }
}
