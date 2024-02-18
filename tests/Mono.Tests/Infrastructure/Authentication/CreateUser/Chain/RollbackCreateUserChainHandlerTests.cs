// <copyright file="RollbackCreateUserChainHandlerTests.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Mono.Infrastructure.Authentication.Common.Interfaces;
using Mono.Infrastructure.Authentication.Common.Models;
using Mono.Infrastructure.Authentication.CreateUser;
using Mono.Infrastructure.Authentication.CreateUser.Chain;
using Mono.Tests.Common;
using Moq;

namespace Mono.Tests.Infrastructure.Authentication.CreateUser.Chain
{
    [TestClass]
    public class RollbackCreateUserChainHandlerTests
    {
        private readonly Mock<IUserManager> _userManager;
        private readonly RollbackCreateUserChainHandler _handler;

        public RollbackCreateUserChainHandlerTests()
        {
            _userManager = new Mock<IUserManager>();
            _handler = new RollbackCreateUserChainHandler(null, _userManager.Object);
        }

        [TestMethod]
        public async Task DoWork_OperationSuccessful_ReturnsPayload()
        {
            await _handler.DoWork(
                CreateUserPayload.FromRequest(new CreateUserRequest(
                    string.Empty, string.Empty, string.Empty)),
                CancellationToken.None);

            _userManager.Verify(x => x.FindUserByName(It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public async Task DoWork_NullUser_ReturnsFaultedPayload()
        {
            _userManager.Setup(x => x.FindUserByName(It.IsAny<string>()))
                .ReturnsAsync(() => null);

            var payload = CreateUserPayload.FromRequest(new CreateUserRequest(
                string.Empty, string.Empty, string.Empty));

            payload.CreateCustomerFailed();

            var result = await _handler.DoWork(payload, CancellationToken.None);

            Assert.IsTrue(result.IsFaulted);

            _userManager.Verify(x => x.DeleteUser(It.IsAny<User>()), Times.Never);
        }

        [TestMethod]
        public async Task DoWork_DeleteUserFails_ReturnsFaultedPayload()
        {
            _userManager.Setup(x => x.FindUserByName(It.IsAny<string>()))
                .ReturnsAsync(TestHelpers.ValidUser);

            _userManager.Setup(x => x.DeleteUser(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Failed());

            var payload = CreateUserPayload.FromRequest(new CreateUserRequest(
                string.Empty, string.Empty, string.Empty));

            payload.CreateCustomerFailed();

            var result = await _handler.DoWork(payload, CancellationToken.None);

            Assert.IsTrue(result.IsFaulted);
        }

        [TestMethod]
        public async Task DoWork_RollbackUserSuccess_ReturnsPayload()
        {
            _userManager.Setup(x => x.FindUserByName(It.IsAny<string>()))
                .ReturnsAsync(TestHelpers.ValidUser);

            _userManager.Setup(x => x.DeleteUser(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Success);

            var payload = CreateUserPayload.FromRequest(new CreateUserRequest(
                string.Empty, string.Empty, string.Empty));

            payload.CreateCustomerFailed();

            var result = await _handler.DoWork(payload, CancellationToken.None);

            Assert.IsFalse(result.IsFaulted);
        }
    }
}
