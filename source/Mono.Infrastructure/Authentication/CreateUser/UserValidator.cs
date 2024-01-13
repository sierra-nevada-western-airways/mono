// <copyright file="UserValidator.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using FluentValidation;
using Mono.Infrastructure.Authentication.Common.Models;

namespace Mono.Infrastructure.Authentication.CreateUser
{
    /// <summary>
    /// Validator for user objects.
    /// </summary>
    internal class UserValidator : AbstractValidator<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserValidator"/> class.
        /// </summary>
        public UserValidator()
        {
            RuleFor(user => user.Id).NotEqual(Guid.Empty);
        }
    }
}
