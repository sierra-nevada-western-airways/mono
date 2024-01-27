// <copyright file="CreateCustomerHandlerIntegrationTests.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Mono.Application.Customers.CreateCustomer;
using Mono.Tests.Common;

namespace Mono.Tests.Application.Customers
{
    [TestClass]
    public class CreateCustomerHandlerIntegrationTests : BaseIntegrationTest
    {
        [TestMethod]
        public async Task Handle_Success_AddCustomerToPersistence()
        {
            var handler = IntegrationHelpers.GetNotificationHandler<CustomerCreated>();

            await handler.Handle(new CustomerCreated(Guid.NewGuid()), CancellationToken.None);

            var context = await IntegrationHelpers.GetApplicationContext().Customers.ToListAsync();

            Assert.IsTrue(context.Count == 1);
        }
    }
}
