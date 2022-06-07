using Moq;
using Newtonsoft.Json;
using Nito.AsyncEx;
using NUnit.Framework;
using System.IO;
using TourPlanner.FileSystem.Handler;
using TourPlanner.FileSystem.JSON;
using TourPlanner.Model;

namespace TourPlanner.FileSystem.Test
{
    public class JsonFileHandlerTest
    {
        private IFileHandler _fileHandler;

        [SetUp]
        public void Setup()
        {
            this._fileHandler = new JSONFileHandler();
        }

        [Test]
        public void ReadShouldBeReturnJSONData_Test()
        {
            string filePath = Constraint.BASEURL + "\\TourPlanner.Server.DL\\Config\\TourPlannerDbConfig.json";
            
            var data = AsyncContext.Run(() => this._fileHandler.Read(filePath));

            Assert.NotNull(data.Item1);
        }

        [Test]
        public void WriteShouldBeReturnJSONData_Test()
        {
            string filePath = Constraint.BASEURL + "\\TourPlanner.Server.DL\\JsonDb\\mock.json";

            var tourMock = new Mock<Tour>();

            var settings = new Newtonsoft.Json.JsonSerializerSettings();
            // This tells your serializer that multiple references are okay.
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            var retrievedPosts = AsyncContext.Run(() => this._fileHandler.Write(filePath, JsonConvert.SerializeObject(tourMock, settings)));

            Assert.IsTrue(retrievedPosts.Item1);
        }
    }
}
