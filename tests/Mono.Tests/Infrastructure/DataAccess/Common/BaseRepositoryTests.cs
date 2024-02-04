// <copyright file="BaseRepositoryTests.cs" company="Sierra Nevada Western Airways LLC">
// Copyright (c) Sierra Nevada Western Airways LLC. All rights reserved.
// </copyright>

using MediatR;
using Mono.Domain.Common;
using Mono.Infrastructure.DataAccess.Common;
using Mono.Tests.Common;
using Moq;

namespace Mono.Tests.Infrastructure.DataAccess.Common
{
    [TestClass]
    public class BaseRepositoryTests
    {
        private readonly Mock<IApplicationContext<TestEntity>> _applicationContext;
        private readonly Mock<IPublisher> _publisher;
        private readonly TestBaseRepository _baseRepository;

        public BaseRepositoryTests()
        {
            _applicationContext = new Mock<IApplicationContext<TestEntity>>();
            _publisher = new Mock<IPublisher>();
            _baseRepository = new TestBaseRepository(_publisher.Object, _applicationContext.Object);
        }

        [TestMethod]
        public async Task CreateEntity_OnException_ReturnsCorrectResult()
        {
            _applicationContext.Setup(x => x.AddEntity(It.IsAny<TestEntity>(), CancellationToken.None))
                .ThrowsAsync(new Exception());

            var result = await _baseRepository.CreateEntity(new TestEntity());

            Assert.IsFalse(result.IsSuccess);
        }

        [TestMethod]
        public async Task CreateEntity_NoAffectedRows_ReturnsCorrectResult()
        {
            _applicationContext.Setup(x => x.AddEntity(It.IsAny<TestEntity>(), CancellationToken.None))
                .ReturnsAsync(0);

            var result = await _baseRepository.CreateEntity(new TestEntity());

            Assert.IsFalse(result.IsSuccess);
        }

        [TestMethod]
        public async Task CreateEntity_Success_ReturnsCorrectResult()
        {
            _applicationContext.Setup(x => x.AddEntity(It.IsAny<TestEntity>(), CancellationToken.None))
                .ReturnsAsync(1);

            var result = await _baseRepository.CreateEntity(new TestEntity());

            Assert.IsTrue(result.IsSuccess);
            _publisher.Verify(x => x.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        public class TestEntity : AggregateRoot
        {
            public TestEntity()
            {
                AddNotification(TestHelpers.TestNotificationInstance());
            }
        }

        internal class TestBaseRepository : BaseRepository<TestEntity>
        {
            public TestBaseRepository(IPublisher publisher, IApplicationContext<TestEntity> applicationContext)
                : base(publisher, applicationContext)
            {
            }
        }
    }
}
