// <copyright file="CustomerController.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mono.Infrastructure.Authentication.CreateCustomer;

namespace Mono.API.Controllers
{
    /// <summary>
    /// Controller for managing customers and their accounts.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// End-point for creating a new customer.
        /// </summary>
        /// <param name="request">A <see cref="CreateCustomerRequest"/> object.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/>.</returns>
        [AllowAnonymous]
        [HttpPost("", Name = "CreateCustomer")]
        [ProducesResponseType(typeof(CreateCustomerResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateCustomer(CreateCustomerRequest request)
        {
            var result = await _mediator.Send(request);

            return Created(new Uri(string.Empty), result);
        }
    }
}
