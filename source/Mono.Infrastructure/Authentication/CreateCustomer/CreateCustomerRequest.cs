﻿// <copyright file="CreateCustomerRequest.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Mono.Infrastructure.Authentication.CreateCustomer
{
    /// <summary>
    /// Request class for creating a new customer.
    /// </summary>
    public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerRequest"/> class.
        /// </summary>
        /// <param name="userName">The customer username.</param>
        /// <param name="password">The customer password.</param>
        /// <param name="email">The customer email.</param>
        public CreateCustomerRequest(string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
        }

        /// <summary>
        /// Gets the customer username.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; }

        /// <summary>
        /// Gets the customer password.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Password { get; }

        /// <summary>
        /// Gets the customer email.
        /// </summary>
        [EmailAddress]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; }
    }
}
