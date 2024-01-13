// <copyright file="EntityResponse.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Mono.Application.Common.Responses
{
    /// <summary>
    /// Common response for entities.
    /// </summary>
    public abstract class EntityResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityResponse"/> class.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        protected EntityResponse(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the entity identifier.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public Guid Id { get; }
    }
}
