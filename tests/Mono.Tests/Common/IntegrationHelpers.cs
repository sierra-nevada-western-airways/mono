// <copyright file="IntegrationHelpers.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mono.Infrastructure.Authentication.Common.Models;
using Mono.Infrastructure.Authentication.DataAccess;
using Mono.Infrastructure.DataAccess.Common;
using Mono.Infrastructure.Dependencies;

namespace Mono.Tests.Common
{
    internal static class IntegrationHelpers
    {
        private static IServiceProvider? _provider;

        public static IRequestHandler<TRequest, IEnvelope<TResponse>> GetHandler<TRequest, TResponse>()
            where TRequest : IEnvelopeRequest<TResponse>
        {
            return GetService<IRequestHandler<TRequest, IEnvelope<TResponse>>>();
        }

        public static INotificationHandler<TNotification> GetNotificationHandler<TNotification>()
            where TNotification : INotification
        {
            return GetService<INotificationHandler<TNotification>>();
        }

        public static ApplicationContext GetApplicationContext()
        {
            return GetService<ApplicationContext>();
        }

        public static UserContext GetUserContext()
        {
            return GetService<UserContext>();
        }

        public static TService GetService<TService>()
            where TService : class
        {
            return Container().GetRequiredService<TService>();
        }

        public static void ClearDatabases()
        {
            var applicationContext = GetApplicationContext();
            var userContext = GetUserContext();

            userContext.Users.ExecuteDelete();

            userContext.SaveChanges();

            applicationContext.Customers.ExecuteDelete();

            applicationContext.SaveChanges();
        }

        private static IServiceProvider Container()
        {
            if (_provider == null)
            {
                var services = new ServiceCollection();

                services.AddApplication();

                var data = new List<KeyValuePair<string, string?>>
                {
                    KeyValuePair.Create<string, string?>("Identity:Audience", Guid.NewGuid().ToString()),
                    KeyValuePair.Create<string, string?>("Identity:Issuer", Guid.NewGuid().ToString()),
                    KeyValuePair.Create<string, string?>("Identity:Key", Guid.NewGuid().ToString()),
                };

                services.AddIdentityAuthentication(new ConfigurationManager().AddInMemoryCollection(data).Build());
                services.AddLogging();

                var userConnection = Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION_STRING") ??
                                            "Server=.\\SQLExpress;Database=Mono.Identity.Tests;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=true";

                var applicationConnection = Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION_STRING") ??
                                       "Server=.\\SQLExpress;Database=Mono.Application.Tests;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=true";

                services.AddDataAccess(userConnection, applicationConnection);

                _provider = services.BuildServiceProvider();
            }

            return _provider;
        }
    }
}
