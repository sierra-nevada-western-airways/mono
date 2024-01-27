// <copyright file="ApplicationDependencies.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Mono.Infrastructure.Dependencies
{
    /// <summary>
    /// Module for the application.
    /// </summary>
    public static class ApplicationDependencies
    {
        /// <summary>
        /// Add the application dependencies.
        /// </summary>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(
                Assembly.Load("Mono.Application"),
                Assembly.Load("Mono.Infrastructure")));
        }
    }
}
