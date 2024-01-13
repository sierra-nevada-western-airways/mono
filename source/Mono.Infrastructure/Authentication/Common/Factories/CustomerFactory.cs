// <copyright file="CustomerFactory.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using System.Security.Claims;
using Mono.Infrastructure.Authentication.Common.Models;
using Mono.Infrastructure.Authentication.CreateCustomer;
using Mono.Infrastructure.Authentication.UserNameSignIn;

namespace Mono.Infrastructure.Authentication.Common.Factories
{
    /// <summary>
    /// Factory for customers.
    /// </summary>
    internal static class CustomerFactory
    {
        /// <summary>
        /// Creates a new customer from a request.
        /// </summary>
        /// <param name="request">A <see cref="CreateCustomerRequest"/> object.</param>
        /// <returns>A new <see cref="Customer"/> instance.</returns>
        public static Customer FromRequest(CreateCustomerRequest request)
        {
            return new Customer(request.UserName, request.Email);
        }

        /// <summary>
        /// Creates a new customer response from an entity.
        /// </summary>
        /// <param name="customer">A <see cref="Customer"/>.</param>
        /// <returns>A new <see cref="CreateCustomerResponse"/> instance.</returns>
        public static CreateCustomerResponse FromCustomer(Customer customer)
        {
            return new CreateCustomerResponse(customer.Id);
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
        /// Creates a list of claims from a customer.
        /// </summary>
        /// <param name="customer">A <see cref="Customer"/>.</param>
        /// <returns>A <see cref="IEnumerable{T}"/> of <see cref="Claim"/>.</returns>
        public static IEnumerable<Claim> CustomerClaims(Customer customer)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
                new Claim(ClaimTypes.Name, customer.UserNameValue),
            };
        }
    }
}
