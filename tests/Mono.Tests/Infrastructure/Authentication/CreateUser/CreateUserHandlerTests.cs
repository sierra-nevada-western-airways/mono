// <copyright file="CreateUserHandlerTests.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using ChainStrategy;
using Mono.Infrastructure.Authentication.CreateUser;
using Mono.Infrastructure.Authentication.CreateUser.Chain;
using Mono.Tests.Common;
using Moq;

namespace Mono.Tests.Infrastructure.Authentication.CreateUser
{
    [TestClass]
    public class CreateUserHandlerTests
    {
        private readonly Mock<IChainFactory> _chainFactory;
        private readonly CreateUserHandler _handler;

        public CreateUserHandlerTests()
        {
            _chainFactory = new Mock<IChainFactory>();
            _handler = new CreateUserHandler(_chainFactory.Object);
        }

        [TestMethod]
        public async Task Handle_FaultedPayload_ReturnsCorrectResponse()
        {
            var request = new CreateUserRequest(string.Empty, string.Empty, string.Empty);

            var payload = CreateUserPayload.FromRequest(request);

            payload.Faulted();

            _chainFactory.Setup(x => x.Execute(It.IsAny<CreateUserPayload>(), CancellationToken.None))
                .ReturnsAsync(payload);

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.IsNull(result.Response);
        }

        [TestMethod]
        public async Task Handle_SuccessfulPayload_ReturnsCorrectResponse()
        {
            var request = new CreateUserRequest(string.Empty, string.Empty, string.Empty);

            var payload = CreateUserPayload.FromRequest(request);

            payload.AddUser(TestHelpers.ValidUser());

            _chainFactory.Setup(x => x.Execute(It.IsAny<CreateUserPayload>(), CancellationToken.None))
                .ReturnsAsync(payload);

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.IsNotNull(result.Response);
        }
    }
}
