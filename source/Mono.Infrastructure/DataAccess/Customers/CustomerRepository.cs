// <copyright file="CustomerRepository.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatR;
using Mono.Application.Customers.Common;
using Mono.Domain.Customers;
using Mono.Infrastructure.DataAccess.Common;

namespace Mono.Infrastructure.DataAccess.Customers
{
    /// <summary>
    /// Persistence object for Customers.
    /// </summary>
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="publisher">An instance of the <see cref="IPublisher"/> interface.</param>
        /// <param name="applicationContext">An instance of the <see cref="IApplicationContext"/> interface.</param>
        public CustomerRepository(IPublisher publisher, IApplicationContext applicationContext)
            : base(publisher, applicationContext)
        {
        }
    }
}
