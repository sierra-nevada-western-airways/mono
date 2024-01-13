// <copyright file="CustomerFactory.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Mono.Infrastructure.Authentication.Common.Models;
using Mono.Infrastructure.Authentication.CreateCustomer;

namespace Mono.Infrastructure.Authentication.Common.Factories
{
    /// <summary>
    /// Factory for customers.
    /// </summary>
    internal static class CustomerFactory
    {
        /// <summary>
        /// Creates a new customer from a request.
        /// </summary>
        /// <param name="request">A <see cref="CreateCustomerRequest"/> object.</param>
        /// <returns>A new <see cref="Customer"/> instance.</returns>
        public static Customer FromRequest(CreateCustomerRequest request)
        {
            return new Customer();
        }
    }
}
