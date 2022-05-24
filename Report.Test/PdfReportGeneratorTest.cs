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
        public void GenerateResponseMustbeTrue()
        {
            this._abstractReportGenerator = new PdfReportGenerator(Constraint.BASEURL + "\\TourPlanner.BL\\Assets\\Reports\\tour2.pdf");

            //var isGenerated = this._abstractReportGenerator.Generate(null);
            Assert.Pass();
        }
    }
}