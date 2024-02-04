// <copyright file="TestHelpers.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatR;
using Mono.Infrastructure.Authentication.Common.Models;

namespace Mono.Tests.Common
{
    internal static class TestHelpers
    {
        public static User ValidUser()
        {
            return new User("UserName123", "user@user.com");
        }

        public static string UserPassword()
        {
            return "SuperSecret123$!";
        }

        public static INotification TestNotificationInstance()
        {
            return new TestNotification();
        }

        internal class TestNotification : INotification
        {
        }
    }
}
