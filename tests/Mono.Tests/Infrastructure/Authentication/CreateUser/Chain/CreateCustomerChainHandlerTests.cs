// <copyright file="CreateCustomerChainHandlerTests.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Mono.Application.Common.Responses;
using Mono.Application.Customers.Common;
using Mono.Domain.Customers;
using Mono.Infrastructure.Authentication.CreateUser;
using Mono.Infrastructure.Authentication.CreateUser.Chain;
using Moq;

namespace Mono.Tests.Infrastructure.Authentication.CreateUser.Chain
{
    public class CreateCustomerChainHandlerTests
    {
        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly CreateCustomerChainHandler _handler;

        public CreateCustomerChainHandlerTests()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _handler = new CreateCustomerChainHandler(null, _customerRepository.Object);
        }

        [TestMethod]
        public async Task Handle_FailedEntityCreation_ReturnsCorrectResponse()
        {
            _customerRepository.Setup(x => x.CreateEntity(It.IsAny<Customer>(), CancellationToken.None))
                .ReturnsAsync(Result.Failure);

            var result = await _handler.Handle(
                CreateUserPayload.FromRequest(
                    new CreateUserRequest(
                    "userName",
                    "password",
                    "user@user.com")),
                CancellationToken.None);

            Assert.IsTrue(result.IsFaulted);
        }

        [TestMethod]
        public async Task Handle_Success_ReturnsCorrectResponse()
        {
            _customerRepository.Setup(x => x.CreateEntity(It.IsAny<Customer>(), CancellationToken.None))
                .ReturnsAsync(Result.Success);

            var result = await _handler.Handle(
                CreateUserPayload.FromRequest(
                    new CreateUserRequest(
                        "userName",
                        "password",
                        "user@user.com")),
                CancellationToken.None);

            Assert.IsFalse(result.IsFaulted);
        }
    }
}
