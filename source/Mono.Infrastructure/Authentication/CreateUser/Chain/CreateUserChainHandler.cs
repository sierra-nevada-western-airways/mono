// <copyright file="CreateUserChainHandler.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using ChainStrategy;
using Mono.Infrastructure.Authentication.Common.Factories;
using Mono.Infrastructure.Authentication.Common.Interfaces;

namespace Mono.Infrastructure.Authentication.CreateUser.Chain
{
    /// <summary>
    /// Handler for the <see cref="CreateUserPayload"/> class.
    /// </summary>
    public class CreateUserChainHandler : ChainHandler<CreateUserPayload>
    {
        private readonly IUserManager _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserChainHandler"/> class.
        /// </summary>
        /// <param name="handler">The next handler in the chain.</param>
        /// <param name="userManager">An instance of the <see cref="IUserManager"/> interface.</param>
        public CreateUserChainHandler(IChainHandler<CreateUserPayload>? handler, IUserManager userManager)
            : base(handler)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Handles the payload for creating a user.
        /// </summary>
        /// <param name="payload">A <see cref="CreateUserPayload"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public override async Task<CreateUserPayload> DoWork(CreateUserPayload payload, CancellationToken cancellationToken)
        {
            var user = UserFactory.UserFromPayload(payload);

            var result = await _userManager.CreateUser(user, payload.Request.Password);

            if (!result.Succeeded)
            {
                payload.Faulted();

                return payload;
            }

            payload.AddUser(user);

            return payload;
        }
    }
}
