// <copyright file="CreateUserPayload.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using ChainStrategy;

namespace Mono.Infrastructure.Authentication.CreateUser.Chain
{
    /// <summary>
    /// Payload object for creating a user.
    /// </summary>
    public class CreateUserPayload : ChainPayload
    {
        private CreateUserPayload(CreateUserRequest request)
        {
            Request = request;
            Response = default!;
        }

        /// <summary>
        /// Gets the request object.
        /// </summary>
        public CreateUserRequest Request { get; }

        /// <summary>
        /// Gets the payload response.
        /// </summary>
        public CreateUserResponse Response { get; private set; }

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
        /// Appends the response to the payload.
        /// </summary>
        /// <param name="response">A <see cref="CreateUserResponse"/> instance.</param>
        public void AddResponse(CreateUserResponse response)
        {
            Response = response;
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
