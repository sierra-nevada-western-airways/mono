// <copyright file="CreateUserPayload.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using ChainStrategy;
using Mono.Infrastructure.Authentication.Common.Models;

namespace Mono.Infrastructure.Authentication.CreateUser.Chain
{
    /// <summary>
    /// Payload object for creating a user.
    /// </summary>
    public class CreateUserPayload : ChainPayload
    {
        private User? _user;

        private CreateUserPayload(CreateUserRequest request)
        {
            Request = request;
        }

        /// <summary>
        /// Gets the request object.
        /// </summary>
        public CreateUserRequest Request { get; }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        public User User => _user ?? throw new NullReferenceException(nameof(_user));

        /// <summary>
        /// Gets a value indicating whether the user should be rolled back.
        /// </summary>
        public bool ShouldRollbackUser { get; private set; }

        /// <summary>
        /// Instantiates the payload from a request object.
        /// </summary>
        /// <param name="request">A <see cref="CreateUserRequest"/> object.</param>
        /// <returns>A new <see cref="CreateUserPayload"/> instance.</returns>
        public static CreateUserPayload FromRequest(CreateUserRequest request)
        {
            return new CreateUserPayload(request);
        }

        /// <summary>
        /// Appends the user identifier to the payload.
        /// </summary>
        /// <param name="user">The user for the payload.</param>
        public void AddUser(User user)
        {
            _user = user;
        }

        /// <summary>
        /// Indicates that the customer creation has failed.
        /// </summary>
        public void CreateCustomerFailed()
        {
            ShouldRollbackUser = true;
        }
    }
}
