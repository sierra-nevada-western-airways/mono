// <copyright file="UserFactory.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using System.Security.Claims;
using Mono.Domain.Customers;
using Mono.Infrastructure.Authentication.Common.Models;
using Mono.Infrastructure.Authentication.CreateUser;
using Mono.Infrastructure.Authentication.CreateUser.Chain;
using Mono.Infrastructure.Authentication.UserNameSignIn;

namespace Mono.Infrastructure.Authentication.Common.Factories
{
    /// <summary>
    /// Factory for customers.
    /// </summary>
    internal static class UserFactory
    {
        /// <summary>
        /// Creates a new user from a payload.
        /// </summary>
        /// <param name="payload">A <see cref="CreateUserPayload"/> object.</param>
        /// <returns>A new <see cref="User"/> instance.</returns>
        public static User UserFromPayload(CreateUserPayload payload)
        {
            return new User(payload.Request.UserName, payload.Request.Email);
        }

        /// <summary>
        /// Create a new customer from a payload.
        /// </summary>
        /// <param name="payload">A <see cref="CreateUserPayload"/> object.</param>
        /// <returns>A new <see cref="Customer"/> instance.</returns>
        public static Customer CustomerFromPayload(CreateUserPayload payload)
        {
            return new Customer(payload.User.Id);
        }

        /// <summary>
        /// Creates a new user response from an entity.
        /// </summary>
        /// <param name="user">A <see cref="User"/>.</param>
        /// <returns>A new <see cref="CreateUserResponse"/> instance.</returns>
        public static CreateUserResponse ResponseFromUser(User user)
        {
            return new CreateUserResponse(user.Id);
        }

        /// <summary>
        /// Creates a new username signin response.
        /// </summary>
        /// <param name="bearerToken">The bearer token.</param>
        /// <param name="refreshToken">The refresh token.</param>
        /// <returns>A new <see cref="UserNameSignInResponse"/>.</returns>
        public static UserNameSignInResponse SignInUserNameResponse(string bearerToken, string refreshToken)
        {
            return new UserNameSignInResponse(bearerToken, refreshToken);
        }

        /// <summary>
        /// Creates a list of claims from a user.
        /// </summary>
        /// <param name="user">A <see cref="User"/>.</param>
        /// <returns>A <see cref="IEnumerable{T}"/> of <see cref="Claim"/>.</returns>
        public static IEnumerable<Claim> CustomerClaims(User user)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserNameValue),
            };
        }
    }
}
