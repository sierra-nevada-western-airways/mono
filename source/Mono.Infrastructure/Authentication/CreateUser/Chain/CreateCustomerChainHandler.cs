// <copyright file="CreateCustomerChainHandler.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using ChainStrategy;
using Mono.Application.Customers.Common;
using Mono.Infrastructure.Authentication.Common.Factories;

namespace Mono.Infrastructure.Authentication.CreateUser.Chain
{
    /// <summary>
    /// Handler for the <see cref="CreateUserPayload"/> class.
    /// </summary>
    public class CreateCustomerChainHandler : ChainHandler<CreateUserPayload>
    {
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerChainHandler"/> class.
        /// </summary>
        /// <param name="handler">The next handler in the chain.</param>
        /// <param name="customerRepository">An instance of the <see cref="ICustomerRepository"/> interface.</param>
        public CreateCustomerChainHandler(IChainHandler<CreateUserPayload>? handler, ICustomerRepository customerRepository)
            : base(handler)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Handler method for creating a customer.
        /// </summary>
        /// <param name="payload">A <see cref="CreateUserPayload"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public override async Task<CreateUserPayload> DoWork(CreateUserPayload payload, CancellationToken cancellationToken)
        {
            var customer = UserFactory.CustomerFromPayload(payload);

            var result = await _customerRepository.CreateEntity(customer, cancellationToken);

            if (!result.IsSuccess)
            {
                payload.Faulted();

                return payload;
            }

            return payload;
        }
    }
}
