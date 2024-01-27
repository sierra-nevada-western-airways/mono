// <copyright file="ValueObject.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using System.Reflection;

namespace Mono.Domain.Common
{
    /// <summary>
    /// ValueObject that evaluates equality based on properties.
    /// </summary>
    public class ValueObject : IEquatable<ValueObject>
    {
        /// <summary>
        /// Overrides the equals operator to account for equality.
        /// </summary>
        /// <param name="left">The first <see cref="ValueObject"/>.</param>
        /// <param name="right">The second <see cref="ValueObject"/>.</param>
        /// <returns>A <see cref="bool"/> indicating whether both values are equal.</returns>
        public static bool operator ==(ValueObject left, ValueObject right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Overrides the equals operator to account for not equality.
        /// </summary>
        /// <param name="left">The first <see cref="ValueObject"/>.</param>
        /// <param name="right">The second <see cref="ValueObject"/>.</param>
        /// <returns>A <see cref="bool"/> indicating whether both values are equal.</returns>
        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Tests another value object for equality.
        /// </summary>
        /// <param name="other">The <see cref="ValueObject"/> to compare.</param>
        /// <returns>A <see cref="bool"/> indicating whether both values are equal.</returns>
        public bool Equals(ValueObject? other)
        {
            foreach (var info in GetFieldInfo())
            {
                var left = info.GetValue(this);
                var right = info.GetValue(other);

                if (left == null)
                {
                    return false;
                }

                if (!left.Equals(right))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Tests another value object for equality.
        /// </summary>
        /// <param name="obj">An object to compare against.</param>
        /// <returns>A <see cref="bool"/> indicating whether both values are equal.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is ValueObject valueObject)
            {
                return Equals(valueObject);
            }

            return false;
        }

        /// <summary>
        /// Returns the hash code for the object.
        /// </summary>
        /// <returns>A <see cref="int"/> representing the object hashcode.</returns>
        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }

        private IEnumerable<FieldInfo> GetFieldInfo()
        {
            return GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).ToList();
        }
    }
}
