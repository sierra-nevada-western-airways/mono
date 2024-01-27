// <copyright file="CreateUserHandler.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using Mono.Infrastructure.Authentication.Common.Factories;
using Mono.Infrastructure.Authentication.Common.Interfaces;

namespace Mono.Infrastructure.Authentication.CreateUser
{
    /// <summary>
    /// Handler for creating a new user.
    /// </summary>
    internal class CreateUserHandler : IEnvelopeHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserHandler"/> class.
        /// </summary>
        /// <param name="userRepository">An instance of the <see cref="IUserManager"/> interface.</param>
        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Handler method for creating a new user.
        /// </summary>
        /// <param name="request">A <see cref="CreateUserRequest"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="CreateUserResponse"/>.</returns>
        public async Task<IEnvelope<CreateUserResponse>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var customer = UserFactory.FromRequest(request);

            var result = await _userRepository.CreateUser(customer, request.Password, cancellationToken);

            if (!result.Succeeded)
            {
                return Envelope<CreateUserResponse>.UserCouldNotBeCreated();
            }

            var response = UserFactory.FromCustomer(customer);

            return Envelope<CreateUserResponse>.Success(response);
        }
    }
}
