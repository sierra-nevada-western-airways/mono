// <copyright file="CustomerContext.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mono.Infrastructure.Authentication.Common.Models;

namespace Mono.Infrastructure.Authentication.DataAccess
{
    /// <summary>
    /// Context for persisting identity customers.
    /// </summary>
    internal sealed class CustomerContext : IdentityDbContext<Customer, IdentityRole<Guid>, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerContext"/> class.
        /// </summary>
        /// <param name="options">An instance of the <see cref="DbContextOptions"/> configuration.</param>
        public CustomerContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();

            RefreshTokens = Set<RefreshToken>();
        }

        /// <summary>
        /// Gets the refresh token db set.
        /// </summary>
        public DbSet<RefreshToken> RefreshTokens { get; }

        /// <summary>
        /// Defines the models for the context.
        /// </summary>
        /// <param name="builder">An instance of the <see cref="ModelBuilder"/>.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<RefreshToken>()
                .HasOne(token => token.Customer);

            builder.Entity<RefreshToken>(typeBuilder =>
            {
                typeBuilder.HasKey(token => token.Token);
                typeBuilder.Property(token => token.ExpiresAt);
            });
        }
    }
}
