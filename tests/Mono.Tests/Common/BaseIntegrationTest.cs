// <copyright file="BaseIntegrationTest.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

namespace Mono.Tests.Common
{
    public abstract class BaseIntegrationTest
    {
        protected BaseIntegrationTest()
        {
            IntegrationHelpers.ClearDatabases();
        }
    }
}
