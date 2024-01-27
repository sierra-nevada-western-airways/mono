// <copyright file="UserNameSignInHandler.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using Mono.Infrastructure.Authentication.Common.Factories;
using Mono.Infrastructure.Authentication.Common.Interfaces;

namespace Mono.Infrastructure.Authentication.UserNameSignIn
{
    /// <summary>
    /// Handler for a username signin.
    /// </summary>
    internal class UserNameSignInHandler : IEnvelopeHandler<UserNameSignInRequest, UserNameSignInResponse>
    {
        private readonly ITokenService _tokenService;
        private readonly ICustomerManager _customerManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserNameSignInHandler"/> class.
        /// </summary>
        /// <param name="tokenService">An instance of the <see cref="ITokenService"/> interface.</param>
        /// <param name="customerManager">An instance of the <see cref="ICustomerManager"/> interface.</param>
        public UserNameSignInHandler(ITokenService tokenService, ICustomerManager customerManager)
        {
            _tokenService = tokenService;
            _customerManager = customerManager;
        }

        /// <summary>
        /// Method for a username signin.
        /// </summary>
        /// <param name="request">A <see cref="UserNameSignInRequest"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="UserNameSignInResponse"/>.</returns>
        public async Task<IEnvelope<UserNameSignInResponse>> Handle(UserNameSignInRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerManager.FindCustomerByUserName(request.UserName);

            if (customer == null)
            {
                throw new Exception(nameof(customer));
            }

            var passwordCorrect = await _customerManager.PasswordIsCorrect(customer, request.Password);

            if (!passwordCorrect)
            {
                throw new Exception(nameof(passwordCorrect));
            }

            var claims = UserFactory.CustomerClaims(customer);

            var bearerToken = _tokenService.GenerateToken(claims);

            var refreshToken = await _tokenService.GenerateRefreshToken(customer, cancellationToken);

            var response = UserFactory.SignInUserNameResponse(bearerToken, refreshToken);

            return Envelope<UserNameSignInResponse>.Success(response);
        }
    }
}
