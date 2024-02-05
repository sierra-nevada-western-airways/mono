// <copyright file="CreateUserChainHandlerTests.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Mono.Infrastructure.Authentication.Common.Interfaces;
using Mono.Infrastructure.Authentication.Common.Models;
using Mono.Infrastructure.Authentication.CreateUser;
using Mono.Infrastructure.Authentication.CreateUser.Chain;
using Moq;

namespace Mono.Tests.Infrastructure.Authentication.CreateUser.Chain
{
    [TestClass]
    public class CreateUserChainHandlerTests
    {
        private readonly Mock<IUserManager> _userManager;
        private readonly CreateUserChainHandler _handler;

        public CreateUserChainHandlerTests()
        {
            _userManager = new Mock<IUserManager>();
            _handler = new CreateUserChainHandler(null, _userManager.Object);
        }

        [TestMethod]
        public async Task DoWork_CreateUserFailed_ReturnsCorrectResponse()
        {
            _userManager.Setup(x => x.CreateUser(
                It.IsAny<User>(),
                It.IsAny<string>())).ReturnsAsync(IdentityResult.Failed());

            var result = await _handler.DoWork(
                CreateUserPayload.FromRequest(new CreateUserRequest(
                "user123241",
                "superSecretPassword",
                "user@user.com")),
                CancellationToken.None);

            Assert.IsTrue(result.IsFaulted);
        }

        [TestMethod]
        public async Task DoWork_CreateUserSuccess_ReturnsCorrectResponse()
        {
            _userManager.Setup(x => x.CreateUser(
                It.IsAny<User>(),
                It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);

            var result = await _handler.DoWork(
                CreateUserPayload.FromRequest(new CreateUserRequest(
                    "user123241",
                    "superSecretPassword",
                    "user@user.com")),
                CancellationToken.None);

            Assert.IsFalse(result.IsFaulted);
        }
    }
}
