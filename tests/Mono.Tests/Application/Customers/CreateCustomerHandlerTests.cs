// <copyright file="CreateCustomerHandlerTests.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Mono.Application.Common.Responses;
using Mono.Application.Customers.Common;
using Mono.Application.Customers.CreateCustomer;
using Mono.Domain.Customers;
using Moq;

namespace Mono.Tests.Application.Customers
{
    [TestClass]
    public class CreateCustomerHandlerTests
    {
        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly CreateCustomerHandler _handler;

        public CreateCustomerHandlerTests()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _handler = new CreateCustomerHandler(_customerRepository.Object);
        }

        [TestMethod]
        public async Task Handle_FailedEntityCreation_ThrowsException()
        {
            _customerRepository.Setup(x => x.CreateEntity(It.IsAny<Customer>(), CancellationToken.None))
                .ReturnsAsync(Result.Failure);

            await Assert.ThrowsExceptionAsync<Exception>(async () => await _handler.Handle(
                new CustomerCreated(Guid.NewGuid()),
                CancellationToken.None));
        }

        [TestMethod]
        public async Task Handle_Success_DoesNotThrowException()
        {
            _customerRepository.Setup(x => x.CreateEntity(It.IsAny<Customer>(), CancellationToken.None))
                .ReturnsAsync(Result.Success);

            await _handler.Handle(new CustomerCreated(Guid.NewGuid()), CancellationToken.None);
        }
    }
}
