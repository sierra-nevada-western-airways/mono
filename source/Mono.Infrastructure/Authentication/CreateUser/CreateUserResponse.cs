// <copyright file="CreateUserResponse.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Mono.Application.Common.Responses;

namespace Mono.Infrastructure.Authentication.CreateUser
{
    /// <summary>
    /// Response class for <see cref="CreateUserRequest"/>.
    /// </summary>
    public class CreateUserResponse : EntityResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserResponse"/> class.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        public CreateUserResponse(Guid id)
            : base(id)
        {
        }
    }
}
