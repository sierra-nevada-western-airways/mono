// <copyright file="SecurityOptions.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

namespace Mono.Infrastructure.Authentication.Common.Models
{
    /// <summary>
    /// Security options for configuration.
    /// </summary>
    internal class SecurityOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityOptions"/> class.
        /// </summary>
        /// <param name="audience">The audience value.</param>
        /// <param name="issuer">The issuer value.</param>
        /// <param name="key">The key value.</param>
        public SecurityOptions(string audience, string issuer, string key)
        {
            Audience = audience;
            Issuer = issuer;
            Key = key;
        }

        /// <summary>
        /// Gets the identity audience.
        /// </summary>
        public string Audience { get; }

        /// <summary>
        /// Gets the identity issuer.
        /// </summary>
        public string Issuer { get; }

        /// <summary>
        /// Gets the identity key.
        /// </summary>
        public string Key { get; }
    }
}
