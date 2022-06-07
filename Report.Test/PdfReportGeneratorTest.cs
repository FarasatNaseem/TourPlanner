using Moq;
using NUnit.Framework;
using TourPlanner.Model;
using TourPlanner.Model.DbSchema;

namespace Report.Test
{
    public class PdfReportGeneratorTest
    {
        private AbstractReportGenerator<TourSchemaWithLog> _abstractReportGenerator;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GenerateResponseMustbeFalse_Test()
        {
            this._abstractReportGenerator = new PdfReportGenerator(Constraint.BASEURL + "\\TourPlanner.BL\\Assets\\Reports\\mocktour.pdf");

            //var tourSchemaMock = new Mock<TourSchemaWithLog>();

            var tourSchemaMock = new TourSchemaWithLog(10, "Test", "Test", "Test", "Test", TransportType.Bike, 2.56, "Test", new System.TimeSpan(), null);

            var isGenerated = this._abstractReportGenerator.Generate(tourSchemaMock);

            Assert.IsFalse(isGenerated);
        }
    }
}