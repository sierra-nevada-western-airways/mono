// <copyright file="ResultTests.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Mono.Application.Common.Responses;

namespace Mono.Tests.Application.Common.Responses
{
    [TestClass]
    public class ResultTests
    {
        [TestMethod]
        public void Success_HasCorrectValue()
        {
            Assert.IsTrue(Result.Success().IsSuccess);
        }

        [TestMethod]
        public void Failure_HasCorrectValue()
        {
            Assert.IsFalse(Result.Failure().IsSuccess);
        }
    }
}
