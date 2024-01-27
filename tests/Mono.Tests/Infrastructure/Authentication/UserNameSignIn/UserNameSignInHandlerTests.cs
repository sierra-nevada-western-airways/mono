// <copyright file="UserNameSignInHandlerTests.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using System.Security.Claims;
using Mono.Infrastructure.Authentication.Common.Interfaces;
using Mono.Infrastructure.Authentication.Common.Models;
using Mono.Infrastructure.Authentication.UserNameSignIn;
using Mono.Tests.Common;
using Moq;

namespace Mono.Tests.Infrastructure.Authentication.UserNameSignIn
{
    [TestClass]
    public class UserNameSignInHandlerTests
    {
        private readonly Mock<ITokenService> _tokenService;
        private readonly Mock<IUserManager> _userManager;
        private readonly UserNameSignInHandler _handler;

        public UserNameSignInHandlerTests()
        {
            _tokenService = new Mock<ITokenService>();
            _userManager = new Mock<IUserManager>();
            _handler = new UserNameSignInHandler(_tokenService.Object, _userManager.Object);
        }

        [TestMethod]
        public async Task Handle_NullCustomer_ReturnsCorrectResponse()
        {
            _userManager.Setup(manager => manager.FindUserByName(It.IsAny<string>()))
                .ReturnsAsync(() => null);

            var result = await _handler.Handle(
                new UserNameSignInRequest(string.Empty, string.Empty),
                CancellationToken.None);

            Assert.IsNull(result.Response);
        }

        [TestMethod]
        public async Task Handle_IncorrectPassword_ReturnsCorrectResponse()
        {
            _userManager.Setup(manager => manager.FindUserByName(It.IsAny<string>()))
                .ReturnsAsync(TestHelpers.ValidUser);

            _userManager.Setup(manager => manager.PasswordIsCorrect(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(false);

            var result = await _handler.Handle(
                new UserNameSignInRequest(string.Empty, string.Empty),
                CancellationToken.None);

            Assert.IsNull(result.Response);
        }

        [TestMethod]
        public async Task Handle_Success_ReturnsCorrectResponse()
        {
            _userManager.Setup(manager => manager.FindUserByName(It.IsAny<string>()))
                .ReturnsAsync(TestHelpers.ValidUser);

            _userManager.Setup(manager => manager.PasswordIsCorrect(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(true);

            _tokenService.Setup(service => service.GenerateToken(It.IsAny<IEnumerable<Claim>>()))
                .Returns(string.Empty);

            _tokenService.Setup(service => service.GenerateRefreshToken(It.IsAny<User>(), CancellationToken.None))
                .ReturnsAsync(string.Empty);

            var result = await _handler.Handle(
                new UserNameSignInRequest(string.Empty, string.Empty),
                CancellationToken.None);

            Assert.IsNotNull(result.Response);
        }
    }
}
