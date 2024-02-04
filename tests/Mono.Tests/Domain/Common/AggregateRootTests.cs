// <copyright file="AggregateRootTests.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Mono.Domain.Common;
using Mono.Tests.Common;

namespace Mono.Tests.Domain.Common
{
    [TestClass]
    public class AggregateRootTests
    {
        [TestMethod]
        public void DefaultConstructor_InstantiatesEvents()
        {
            var root = new TestAggregateRoot();

            Assert.IsNotNull(root.DomainEvents);
        }

        [TestMethod]
        public void NonDefaultConstructor_InstantiatesEvents()
        {
            var root = new TestAggregateRoot(Guid.NewGuid());

            Assert.IsNotNull(root.DomainEvents);
        }

        [TestMethod]
        public void AddNotification_AppendsToEvents()
        {
            var root = new TestAggregateRoot();

            root.AddNotification(TestHelpers.TestNotificationInstance());

            Assert.AreEqual(1, root.DomainEvents.Count());
        }

        internal class TestAggregateRoot : AggregateRoot
        {
            public TestAggregateRoot()
            {
            }

            public TestAggregateRoot(Guid id)
                : base(id)
            {
            }
        }
    }
}
