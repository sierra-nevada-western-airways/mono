// <copyright file="DataAccessDependencies.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mono.Application.Customers.Common;
using Mono.Infrastructure.Authentication.Common.Interfaces;
using Mono.Infrastructure.Authentication.DataAccess;
using Mono.Infrastructure.DataAccess.Common;
using Mono.Infrastructure.DataAccess.Customers;

namespace Mono.Infrastructure.Dependencies
{
    /// <summary>
    /// Module for data access.
    /// </summary>
    public static class DataAccessDependencies
    {
        /// <summary>
        /// Adds data access dependencies.
        /// </summary>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        /// <param name="configuration">An instance of the <see cref="IConfiguration"/> interface.</param>
        public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserContext>(builder => builder.UseSqlServer(configuration.GetConnectionString("Identity")));

            services.AddDbContext<ApplicationContext>(builder => builder.UseSqlServer(configuration.GetConnectionString("Application")));

            services.AddTransient(typeof(IApplicationContext<>), typeof(ApplicationContextDirector<>));
            services.AddTransient<IUserManager, UserDirector>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}
