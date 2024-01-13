// <copyright file="ICustomerRepository.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Mono.Application.Common.DataAccess;
using Mono.Domain.Customers;

namespace Mono.Application.Customers.Common
{
    /// <summary>
    /// Interacts with Customer persistence.
    /// </summary>
    public interface ICustomerRepository
        : ICreateEntity<Customer>
    {
    }
}
