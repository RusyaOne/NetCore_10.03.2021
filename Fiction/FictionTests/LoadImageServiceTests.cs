using Fiction.Services;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System;
using System.Reflection;
using System.Threading;
using Xunit;

namespace FictionTests
{
    public class LoadImageServiceTests
    {
        [Fact]
        public void ExecuteAsync_Success_ImageLoadedToCache()
        {
            //Arrange
            Mock<IExternalImageServiceClient> externalImageServiceClient = new Mock<IExternalImageServiceClient>(MockBehavior.Strict);
            var expected = new byte[] { 0, 1, 2, 3, 4 };
            externalImageServiceClient.Setup(x => x.GetImage()).Returns(expected);

            IMemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());
            var cacheKey = $"image_{DateTime.UtcNow.Date}";

            LoadImageService sut = new LoadImageService(externalImageServiceClient.Object, memoryCache);
            var sutType = typeof(LoadImageService);
            var executeAsyncMethodInfo = sutType.GetMethod("ExecuteAsync", BindingFlags.NonPublic | BindingFlags.Instance);

            //Act
            executeAsyncMethodInfo.Invoke(sut, new object[] { CancellationToken.None });

            //Assert
            var result = memoryCache.Get<byte[]>(cacheKey);
            Assert.Equal(expected, result);
        }
    }
}