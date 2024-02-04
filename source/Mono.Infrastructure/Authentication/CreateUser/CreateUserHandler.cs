// <copyright file="CreateUserHandler.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using ChainStrategy;
using MediatorBuddy;
using Mono.Infrastructure.Authentication.CreateUser.Chain;

namespace Mono.Infrastructure.Authentication.CreateUser
{
    /// <summary>
    /// Handler for creating a new user.
    /// </summary>
    internal class CreateUserHandler : IEnvelopeHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IChainFactory _chainFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserHandler"/> class.
        /// </summary>
        /// <param name="chainFactory">An instance of the <see cref="IChainFactory"/> interface.</param>
        public CreateUserHandler(IChainFactory chainFactory)
        {
            _chainFactory = chainFactory;
        }

        /// <summary>
        /// Handler method for creating a new user.
        /// </summary>
        /// <param name="request">A <see cref="CreateUserRequest"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="CreateUserResponse"/>.</returns>
        public async Task<IEnvelope<CreateUserResponse>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var payload = await _chainFactory.Execute(CreateUserPayload.FromRequest(request), cancellationToken);

            if (payload.IsFaulted)
            {
                return Envelope<CreateUserResponse>.UserCouldNotBeCreated();
            }

            return Envelope<CreateUserResponse>.Success(payload.Response);
        }
    }
}
