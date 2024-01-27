// <copyright file="IntegrationHelpers.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mono.Application.Customers.Common;
using Mono.Infrastructure.Authentication.Common.Models;
using Mono.Infrastructure.Authentication.DataAccess;
using Mono.Infrastructure.DataAccess.Common;
using Mono.Infrastructure.DataAccess.Customers;
using Mono.Infrastructure.Dependencies;

namespace Mono.Tests.Common
{
    internal static class IntegrationHelpers
    {
        private static IServiceProvider? _provider;

        public static IRequestHandler<TRequest, IEnvelope<TResponse>> GetHandler<TRequest, TResponse>()
            where TRequest : IEnvelopeRequest<TResponse>
        {
            return Container().GetRequiredService<IRequestHandler<TRequest, IEnvelope<TResponse>>>();
        }

        public static INotificationHandler<TNotification> GetNotificationHandler<TNotification>()
            where TNotification : INotification
        {
            return Container().GetRequiredService<INotificationHandler<TNotification>>();
        }

        public static ApplicationContext GetDatabaseContext()
        {
            return Container().GetRequiredService<ApplicationContext>();
        }

        public static void ClearDatabase()
        {
            var context = GetDatabaseContext();

            context.Customers.RemoveRange(context.Customers);

            context.SaveChanges();
        }

        private static IServiceProvider Container()
        {
            if (_provider == null)
            {
                var services = new ServiceCollection();

                services.AddApplication();
                services.AddTransient<ICustomerRepository, CustomerRepository>();

                services.AddIdentity<User, IdentityRole<Guid>>()
                    .AddEntityFrameworkStores<UserContext>()
                    .AddDefaultTokenProviders();

                services.AddAuthentication();

                services.AddLogging();

                var connectionString = Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION_STRING") ??
                                       "Server=.\\SQLExpress;Database=Mono.Tests;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=true";

                services.AddDbContext<ApplicationContext>(builder => builder.UseSqlServer(connectionString));

                _provider = services.BuildServiceProvider();
            }

            return _provider;
        }
    }
}
