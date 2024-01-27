// <copyright file="CreateCustomerHandler.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatR;
using Mono.Application.Customers.Common;

namespace Mono.Application.Customers.CreateCustomer
{
    /// <summary>
    /// Handle for creating a customer.
    /// </summary>
    public class CreateCustomerHandler : INotificationHandler<CustomerCreated>
    {
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerHandler"/> class.
        /// </summary>
        /// <param name="customerRepository">An instance of the <see cref="ICustomerRepository"/> interface.</param>
        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Method for creating a customer.
        /// </summary>
        /// <param name="notification">A <see cref="CustomerCreated"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Handle(CustomerCreated notification, CancellationToken cancellationToken)
        {
            var customer = CustomerFactory.CreateCustomer(notification);

            var result = await _customerRepository.CreateEntity(customer, CreateCustomerFailed.Initialize(customer.Id), cancellationToken);

            if (!result.IsSuccess)
            {
                throw new Exception(nameof(result));
            }
        }
    }
}
