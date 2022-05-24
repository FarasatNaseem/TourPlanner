using Nito.AsyncEx;
using NUnit.Framework;
using TourPlanner.FileSystem.Handler;
using TourPlanner.FileSystem.JSON;

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
            string filePath = @"C:\Users\Privat\TourPlanner\TourPlanner.Server.DL\Config\TourPlannerDbConfig.json";
            
            var data = AsyncContext.Run(() => this._fileHandler.Read(filePath));

            Assert.NotNull(data.Item1);
        }
    }
}
