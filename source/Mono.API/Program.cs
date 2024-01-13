// <copyright file="Program.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Mono.Infrastructure.Dependencies;

namespace Mono.API
{
    /// <summary>
    /// Entry point for the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry method for the application.
        /// </summary>
        /// <param name="args">Command line starting arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerAuthentication();
            builder.Services.AddApplication();
            builder.Services.AddIdentityAuthentication(builder.Configuration);
            builder.Services.AddDataAccess(builder.Configuration);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
