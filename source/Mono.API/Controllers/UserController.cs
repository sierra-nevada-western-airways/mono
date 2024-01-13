// <copyright file="UserController.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mono.Infrastructure.Authentication.CreateUser;
using Mono.Infrastructure.Authentication.UserNameSignIn;

namespace Mono.API.Controllers
{
    /// <summary>
    /// Controller for managing customers and their accounts.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// End-point for creating a new customer.
        /// </summary>
        /// <param name="request">A <see cref="CreateUserRequest"/> object.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        [AllowAnonymous]
        [HttpPost("", Name = "CreateUser")]
        [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            var response = await _mediator.Send(request);

            return Created(new Uri($"Customer/{response.Id}", UriKind.Relative), response);
        }

        /// <summary>
        /// End-point for singing in via a username.
        /// </summary>
        /// <param name="request">A <see cref="UserNameSignInRequest"/> object.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        [AllowAnonymous]
        [HttpPost("SignIn/Username", Name = "UserNameSignIn")]
        [ProducesResponseType(typeof(UserNameSignInResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UserNameSignIn(UserNameSignInRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
