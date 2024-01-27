// <copyright file="EntityTests.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Mono.Domain.Common;

namespace Mono.Tests.Domain.Common
{
    [TestClass]
    public class EntityTests
    {
        [TestMethod]
        public void DefaultConstructor_InstantiatesId()
        {
            var entity = new TestEntity();

            Assert.AreNotEqual(Guid.Empty, entity.Id);
        }

        [TestMethod]
        public void Constructor_EmptyId_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new TestEntity(Guid.Empty));
        }

        [TestMethod]
        public void Equals_NullEntity_ReturnsFalse()
        {
            var entity = new TestEntity();

            Assert.IsFalse(entity.Equals(null));
        }

        [TestMethod]
        public void Equals_NonNullEntity_ReturnsTrue()
        {
            var id = Guid.NewGuid();

            var first = new TestEntity(id);
            var second = new TestEntity(id);

            Assert.IsTrue(first.Equals(second));
        }

        [TestMethod]
        public void Equals_EntityObject_ReturnsTrue()
        {
            var id = Guid.NewGuid();

            var first = new TestEntity(id);
            object second = new TestEntity(id);

            Assert.IsTrue(first.Equals(second));
        }

        [TestMethod]
        public void Equals_NonEntityObject_ReturnsFalse()
        {
            var first = new TestEntity();
            object second = "notAnEntity";

            Assert.IsFalse(first.Equals(second));
        }

        [TestMethod]
        public void GetHaseCode_ReturnsMinimumValue()
        {
            var entity = new TestEntity();

            Assert.IsTrue(entity.GetHashCode() > 0);
        }

        internal class TestEntity : Entity
        {
            public TestEntity()
            {
            }

            public TestEntity(Guid id)
                : base(id)
            {
            }
        }
    }
}
