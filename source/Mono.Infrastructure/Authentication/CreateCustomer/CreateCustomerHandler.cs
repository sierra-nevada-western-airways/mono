// <copyright file="CreateCustomerHandler.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatR;
using Mono.Infrastructure.Authentication.Common.Factories;
using Mono.Infrastructure.Authentication.Common.Interfaces;

namespace Mono.Infrastructure.Authentication.CreateCustomer
{
    /// <summary>
    /// Handler for creating a new customer.
    /// </summary>
    internal class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        private readonly ICustomerManager _customerManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerHandler"/> class.
        /// </summary>
        /// <param name="customerManager">An instance of the <see cref="ICustomerManager"/> interface.</param>
        public CreateCustomerHandler(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        /// <summary>
        /// Handler method for creating a new customer.
        /// </summary>
        /// <param name="request">A <see cref="CreateCustomerRequest"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="CreateCustomerResponse"/>.</returns>
        public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = CustomerFactory.FromRequest(request);

            var result = await _customerManager.CreateCustomer(customer, request.Password, cancellationToken);

            if (!result.Succeeded)
            {
                throw new Exception("Bad things.");
            }

            return CustomerFactory.FromCustomer(customer);
        }
    }
}
