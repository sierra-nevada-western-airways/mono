// <copyright file="Result.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

namespace Mono.Application.Common.Responses
{
    /// <summary>
    /// Abstraction for an application result.
    /// </summary>
    public sealed class Result
    {
        private Result(bool result)
        {
            IsSuccess = result;
        }

        /// <summary>
        /// Gets a value indicating whether of the operation.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Designates a successful operation.
        /// </summary>
        /// <returns>A <see cref="Result"/> instance.</returns>
        public static Result Success()
        {
            return new Result(true);
        }

        /// <summary>
        /// Designates a failed operation.
        /// </summary>
        /// <returns>A <see cref="Result"/> instance.</returns>
        public static Result Failure()
        {
            return new Result(false);
        }
    }
}
