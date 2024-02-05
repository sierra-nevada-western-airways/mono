// <copyright file="CreateUserPayloadTests.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Mono.Infrastructure.Authentication.CreateUser;
using Mono.Infrastructure.Authentication.CreateUser.Chain;
using Mono.Tests.Common;

namespace Mono.Tests.Infrastructure.Authentication.CreateUser.Chain
{
    [TestClass]
    public class CreateUserPayloadTests
    {
        [TestMethod]
        public void Payload_User_ThrowsExceptionOnNull()
        {
            var payload = CreateUserPayload.FromRequest(
                new CreateUserRequest(string.Empty, string.Empty, string.Empty));

            Assert.ThrowsException<NullReferenceException>(() => payload.User);
        }

        [TestMethod]
        public void Payload_AddUser_IsAppended()
        {
            var payload = CreateUserPayload.FromRequest(
                new CreateUserRequest(string.Empty, string.Empty, string.Empty));

            payload.AddUser(TestHelpers.ValidUser());

            Assert.IsNotNull(payload.User);
        }

        [TestMethod]
        public void Payload_CreateCustomerFailed_UpdatesState()
        {
            var payload = CreateUserPayload.FromRequest(
                new CreateUserRequest(string.Empty, string.Empty, string.Empty));

            payload.CreateCustomerFailed();

            Assert.IsTrue(payload.ShouldRollbackUser);
        }
    }
}
