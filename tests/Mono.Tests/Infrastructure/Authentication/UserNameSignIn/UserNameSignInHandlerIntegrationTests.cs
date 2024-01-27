// <copyright file="UserNameSignInHandlerIntegrationTests.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Mono.Infrastructure.Authentication.Common.Interfaces;
using Mono.Infrastructure.Authentication.UserNameSignIn;
using Mono.Tests.Common;

namespace Mono.Tests.Infrastructure.Authentication.UserNameSignIn
{
    [TestClass]
    public class UserNameSignInHandlerIntegrationTests : BaseIntegrationTest
    {
        [TestMethod]
        public async Task Handle_Success_SignsInUserFromPersistence()
        {
            var user = TestHelpers.ValidUser();

            var manager = IntegrationHelpers.GetService<IUserManager>();

            await manager.CreateUser(user, TestHelpers.UserPassword());

            var handler = IntegrationHelpers.GetHandler<UserNameSignInRequest, UserNameSignInResponse>();

            var result = await handler.Handle(
                new UserNameSignInRequest(user.UserNameValue, TestHelpers.UserPassword()),
                CancellationToken.None);

            Assert.IsNotNull(result);
        }
    }
}
