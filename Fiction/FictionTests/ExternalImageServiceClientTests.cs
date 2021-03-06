using Fiction.Infrastructure;
using Fiction.Services;
using Microsoft.Extensions.Options;
using Moq;
using RestSharp;
using System;
using Xunit;

namespace FictionTests
{
    public class ExternalImageServiceClientTests
    {
        [Fact]
        public void GetImage_Success_AllRestClientInvocationsCalled()
        {
            //Arrange
            var uri = new Uri("http://localhost:56227");
            var expected = new byte[0];

            Mock<IRestClient> restClient = new Mock<IRestClient>(MockBehavior.Strict);
            restClient.Setup(x => x.Execute(It.IsAny<IRestRequest>())).Returns(new RestResponse { RawBytes = expected });
            restClient.SetupSet(x => x.BaseUrl = uri);

            Mock<IOptions<FictionConfiguration>> configurationOptions = new Mock<IOptions<FictionConfiguration>>(MockBehavior.Strict);
            configurationOptions.SetupGet(x => x.Value).Returns(new FictionConfiguration { ImageClientUrl = "http://localhost:56227" });

            ExternalImageServiceClient sut = new ExternalImageServiceClient(restClient.Object, configurationOptions.Object);

            //Act
            var result = sut.GetImage();

            //Assert
            Assert.Equal(expected, result);
            restClient.Verify(x => x.Execute(It.IsAny<IRestRequest>()), Times.Once);
            restClient.VerifySet(x => x.BaseUrl = uri, Times.Once);
        }

        [Fact]
        public void GetImage_RestClientFailed_ExceptionThrown()
        {
            //Arrange
            var uri = new Uri("http://localhost:56227");
            var expected = new byte[0];

            Mock<IRestClient> restClient = new Mock<IRestClient>(MockBehavior.Strict);
            restClient.Setup(x => x.Execute(It.IsAny<IRestRequest>())).Throws(new Exception());
            restClient.SetupSet(x => x.BaseUrl = uri);

            Mock<IOptions<FictionConfiguration>> configurationOptions = new Mock<IOptions<FictionConfiguration>>(MockBehavior.Strict);
            configurationOptions.SetupGet(x => x.Value).Returns(new FictionConfiguration { ImageClientUrl = "http://localhost:56227" });

            ExternalImageServiceClient sut = new ExternalImageServiceClient(restClient.Object, configurationOptions.Object);

            //Act & Asssert
            Assert.Throws<Exception>(() => sut.GetImage());
        }
    }
}