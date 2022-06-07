using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Nito.AsyncEx;
using NUnit.Framework;
using TourPlanner.Client.DL.Responses;
using TourPlanner.Client.DL.Services;
using TourPlanner.Model;
using TourPlanner.Model.DbSchema;

namespace TourPlanner.Client.DL.Test.ServicesTest
{
    public class AbstractServiceTest
    {
        private AbstractService _service;

        [SetUp]
        public void Setup()
        {
            this._service = new TourService();
        }

        [Test]
        public void CreateMustReturnTrue_Test()
        {
            var tourMock = new Mock<Tour>();

            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
            };
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);

            var retrievedPosts = AsyncContext.Run(() => this._service.Create(tourMock.Object));

            Assert.IsTrue(retrievedPosts.IsCorrectlyResponded);
        }

        [Test]
        public void DeleteMustReturn_True()
        {
            int id = 1;

            var handlerMock = new Mock<HttpMessageHandler>();

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
            };
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);

            var retrievedPosts = AsyncContext.Run(() => this._service.Delete(id));

            Assert.IsTrue(retrievedPosts.IsCorrectlyResponded);
        }

        [Test]
        public void UpdateMustReturnTrue_Test()
        {
            var tourMock = new Mock<Tour>();

            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
            };
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);

            var retrievedPosts = AsyncContext.Run(() => this._service.Update(tourMock.Object));

            Assert.IsTrue(retrievedPosts.IsCorrectlyResponded);
        }

        [Test]
        public void ImportMustReturnTrue_Test()
        {
            var tourMock = new Mock<List<TourSchemaWithLog>>();


            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
            };
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);

            var retrievedPosts = AsyncContext.Run(() => this._service.Import(tourMock.Object));

            Assert.IsTrue(retrievedPosts.IsCorrectlyResponded);
        }


        [Test]
        public void ReadAllMustReturn_True()
        {
            var handlerMock = new Mock<HttpMessageHandler>();

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
            };
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);

            var retrievedPosts = AsyncContext.Run(() => this._service.ReadAll());

            Assert.IsTrue(retrievedPosts.IsCorrectlyResponded);
        }

        [Test]
        public void ReadByIdMustReturn_True()
        {
            var handlerMock = new Mock<HttpMessageHandler>();

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
            };
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);

            var retrievedPosts = AsyncContext.Run(() => this._service.Read(1));

            Assert.IsNull(retrievedPosts.Data);
        }

        [Test]
        public void ReadListMustReturn_True()
        {
            var handlerMock = new Mock<HttpMessageHandler>();

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
            };
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);

            var retrievedPosts = AsyncContext.Run(() => this._service.ReadLike("sometext"));

            Assert.IsTrue(retrievedPosts.IsCorrectlyResponded);
        }
    }
}
