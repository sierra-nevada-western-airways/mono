// <copyright file="AuthenticationDependencies.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Mono.Infrastructure.Authentication.Common.Interfaces;
using Mono.Infrastructure.Authentication.Common.Models;
using Mono.Infrastructure.Authentication.DataAccess;

namespace Mono.Infrastructure.Dependencies
{
    /// <summary>
    /// Module for authentication.
    /// </summary>
    public static class AuthenticationDependencies
    {
        /// <summary>
        /// Adds all identity dependencies.
        /// </summary>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        /// <param name="configuration">An instance of the <see cref="IConfiguration"/> interface.</param>
        public static void AddIdentityAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var securityOptions = configuration
                .GetSection("Identity")
                .Get<SecurityOptions>() ?? throw new NullReferenceException(nameof(configuration));

            services.AddSingleton(_ => securityOptions);
            services.AddTransient<ITokenService, TokenService>();

            services
                .AddIdentity<User, IdentityRole<Guid>>(
                    options =>
                    {
                        options.User.RequireUniqueEmail = true;
                    })
                .AddEntityFrameworkStores<UserContext>()
                .AddDefaultTokenProviders();

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudience = securityOptions.Audience,
                        ValidIssuer = securityOptions.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityOptions.Key)),
                    };
                });
        }
    }
}
