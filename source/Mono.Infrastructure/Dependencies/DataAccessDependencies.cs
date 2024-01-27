// <copyright file="DataAccessDependencies.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
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
        /// <param name="userContextConnection">Connection string for identity persistence.</param>
        /// <param name="applicationContextConnection">Connection string for application persistence.</param>
        public static void AddDataAccess(this IServiceCollection services, string userContextConnection, string applicationContextConnection)
        {
            services.AddDbContext<UserContext>(builder => builder.UseSqlServer(userContextConnection));

            services.AddDbContext<IApplicationContext, ApplicationContext>(builder => builder.UseSqlServer(applicationContextConnection));

            services.AddTransient<IUserManager, UserDirector>();

            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}
