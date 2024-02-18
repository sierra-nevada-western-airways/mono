// <copyright file="ValueObjectTests.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using Mono.Domain.Common;

namespace Mono.Tests.Domain.Common
{
    [TestClass]
    public class ValueObjectTests
    {
        [TestMethod]
        public void EqualsOperator_ComparesObjects()
        {
            var first = new TestValueObject();
            var second = new TestValueObject();

            Assert.IsTrue(first == second);
        }

        [TestMethod]
        public void NonEqualsOperators_ComparesObjects()
        {
            var first = new TestValueObject();
            first.SetId(10);

            var second = new TestValueObject();

            Assert.IsTrue(first != second);
        }

        [TestMethod]
        public void Equals_ValueObject_EqualValues_ReturnsFalse()
        {
            var first = new TestValueObject();
            var second = new TestValueObject();

            Assert.IsTrue(first.Equals(second));
            Assert.AreEqual(first.Id, second.Id);
            Assert.AreEqual(first.Second, second.Second);
        }

        [TestMethod]
        public void Equals_ValueObject_NullValue_ReturnsFalse()
        {
            var first = new TestValueObject();
            first.SetId(null);

            var second = new TestValueObject();

            Assert.IsFalse(first.Equals(second));
        }

        [TestMethod]
        public void Equals_ValueObject_NonEqualValue_ReturnsFalse()
        {
            var first = new TestValueObject();
            first.SetId(10);

            var second = new TestValueObject();

            Assert.IsFalse(first.Equals(second));
        }

        [TestMethod]
        public void Equals_ObjectValueObject_ReturnsTrue()
        {
            var first = new TestValueObject();
            object second = new TestValueObject();

            Assert.IsTrue(first.Equals(second));
        }

        [TestMethod]
        public void Equals_NonObjectValueObject_ReturnsTrue()
        {
            var first = new TestValueObject();
            object second = "nonValueObject";

            Assert.IsFalse(first.Equals(second));
        }

        [TestMethod]
        public void GetHashCode_ReturnsMinimumValue()
        {
            var valueObject = new TestValueObject();

            Assert.IsTrue(valueObject.GetHashCode() > 1);
        }

        internal class TestValueObject : ValueObject
        {
            private int? _id;

            public TestValueObject()
            {
                _id = 1;
                Second = "second";
            }

            public int? Id => _id;

            public string Second { get; }

            public void SetId(int? id)
            {
                _id = id;
            }
        }
    }
}
