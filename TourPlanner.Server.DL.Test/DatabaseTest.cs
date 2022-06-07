using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TourPlanner.Model;
using TourPlanner.Model.DbSchema;
using TourPlanner.Server.DL.DB;

namespace TourPlanner.Server.DL.Test
{
    public class DatabaseTest
    {
        private Database _tourPlannerDatabase;

        [SetUp]
        public void Setup()
        {
            IConfiguration config = new ConfigurationBuilder()
             .AddJsonFile(Constraint.BASEURL + "TourPlanner.Server.DL\\Config\\TourPlannerDbConfig.json", false, true)
           .Build();

            this._tourPlannerDatabase = new Database(config);
        }

        [Test]
        public void DeleteTourByIdMustReturnTrue_Test()
        {
            var response = this._tourPlannerDatabase.DeleteTourById(10);

            Assert.IsTrue(response.Item1);
        }

        [Test]
        public void StoreBackupMustReturnTrue_Test()
        {
            var tourData = new Mock<List<TourSchemaWithLog>>();

            var response = this._tourPlannerDatabase.StoreBackup(tourData.Object);

            Assert.IsTrue(response.Item1);
        }

        [Test]
        public void GetAllTourWithLogsMustReturnTours_Test()
        {
            var response = this._tourPlannerDatabase.GetAllTourWithLogs();

            Assert.AreEqual("Tours with logs are fetched successfully", response.Item2);
        }

        [Test]
        public void FilterToursMustNotReturnNull_Test()
        {
            var response = this._tourPlannerDatabase.FilterTours("hahahahahah");

            Assert.IsNull(response.Item1);
        }
    }
}