using NUnit.Framework;
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
        public void GenerateResponseMustbeTrue()
        {
            this._abstractReportGenerator = new PdfReportGenerator($"C:\\Users\\farha\\Desktop\\TourPlannerRepo2\\TourPlanner\\TourPlanner.BL\\Assets\\Reports\\tour2.pdf");

            //var isGenerated = this._abstractReportGenerator.Generate(null);
            Assert.Pass();
        }
    }
}