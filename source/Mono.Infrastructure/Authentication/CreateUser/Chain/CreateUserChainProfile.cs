// <copyright file="CreateUserChainProfile.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using ChainStrategy;

namespace Mono.Infrastructure.Authentication.CreateUser.Chain
{
    /// <summary>
    /// Chain profile for the <see cref="CreateUserPayload"/> class.
    /// </summary>
    internal class CreateUserChainProfile : ChainProfile<CreateUserPayload>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserChainProfile"/> class.
        /// </summary>
        public CreateUserChainProfile()
        {
            AddStep<CreateUserChainHandler>()
                .AddStep<CreateCustomerChainHandler>();
        }
    }
}
