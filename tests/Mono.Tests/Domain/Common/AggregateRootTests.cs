// <copyright file="AggregateRootTests.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatR;
using Mono.Domain.Common;

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

            root.AddNotification(new TestNotification());

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

        internal class TestNotification : INotification
        {
        }
    }
}
