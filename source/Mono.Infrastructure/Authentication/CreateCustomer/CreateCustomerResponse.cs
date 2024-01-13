// <copyright file="CreateCustomerResponse.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Mono.Application.Common.Responses;

namespace Mono.Infrastructure.Authentication.CreateCustomer
{
    /// <summary>
    /// Response class for <see cref="CreateCustomerRequest"/>.
    /// </summary>
    public class CreateCustomerResponse : EntityResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerResponse"/> class.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        public CreateCustomerResponse(Guid id)
            : base(id)
        {
        }
    }
}
