// <copyright file="ApplicationContext.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Mono.Domain.Customers;
using Mono.Infrastructure.DataAccess.Customers;

namespace Mono.Infrastructure.DataAccess.Common
{
    /// <summary>
    /// Persistence context for the application.
    /// </summary>
    public sealed class ApplicationContext : DbContext, IApplicationContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        /// <param name="options">A <see cref="DbContextOptions"/> object for configuration.</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();

            Customers = Set<Customer>();
        }

        /// <summary>
        /// Gets the db set for customers.
        /// </summary>
        public DbSet<Customer> Customers { get; }

        /// <summary>
        /// Configures the context models.
        /// </summary>
        /// <param name="modelBuilder">An instance of the <see cref="ModelBuilder"/> object.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new CustomerBuilder().BuildEntity(modelBuilder);
        }
    }
}
