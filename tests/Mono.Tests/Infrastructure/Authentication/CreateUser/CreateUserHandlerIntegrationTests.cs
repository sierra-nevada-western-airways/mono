// <copyright file="CreateUserHandlerIntegrationTests.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Mono.Infrastructure.Authentication.CreateUser;
using Mono.Tests.Common;

namespace Mono.Tests.Infrastructure.Authentication.CreateUser
{
    [TestClass]
    public class CreateUserHandlerIntegrationTests : BaseIntegrationTest
    {
        [TestMethod]
        public async Task Handle_WorksCorrectly()
        {
            var request = new CreateUserRequest(
                "MySuperSecretUser",
                "MySuperSecretPassword123!",
                "user@user.com");

            var handler = IntegrationHelpers.GetHandler<CreateUserRequest, CreateUserResponse>();

            await handler.Handle(request, CancellationToken.None);

            var users = await IntegrationHelpers.GetUserContext().Users.ToListAsync();

            Assert.AreEqual(1, users.Count);

            var customers = await IntegrationHelpers.GetApplicationContext().Customers.ToListAsync();

            Assert.AreEqual(1, customers.Count);
        }
    }
}
