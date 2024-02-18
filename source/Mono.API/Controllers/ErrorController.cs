// <copyright file="ErrorController.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using Microsoft.AspNetCore.Mvc;

namespace Mono.API.Controllers
{
    /// <summary>
    /// Controller for error related documentation.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ErrorController : BaseErrorController
    {
    }
}
