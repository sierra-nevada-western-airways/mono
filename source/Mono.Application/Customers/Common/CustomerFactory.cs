// <copyright file="CustomerFactory.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Mono.Application.Customers.CreateCustomer;
using Mono.Domain.Customers;

namespace Mono.Application.Customers.Common
{
    /// <summary>
    /// Factory class for Customers.
    /// </summary>
    public static class CustomerFactory
    {
        /// <summary>
        /// Instantiates a new customer from an event.
        /// </summary>
        /// <param name="notification">A <see cref="CustomerCreated"/> object.</param>
        /// <returns>A new <see cref="Customer"/> instance.</returns>
        public static Customer CreateCustomer(CustomerCreated notification)
        {
            return new Customer(notification.Id);
        }
    }
}
