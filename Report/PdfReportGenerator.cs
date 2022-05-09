using System.Collections.Generic;
using System.IO;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using TourPlanner.Model.DbSchema;

namespace Report
{
    public class PdfReportGenerator : AbstractReportGenerator<TourSchemaWithLog>
    {
        private readonly PdfWriter _writer;
        private readonly PdfDocument _pdf;
        private readonly Document _document;
        public PdfReportGenerator(string filePath) : base(filePath)
        {
            this._writer = new PdfWriter(filePath);
            this._pdf = new PdfDocument(this._writer);
            this._document = new Document(this._pdf);
        }


        private Paragraph CreateHeader(string headerText)
        {
            return new Paragraph(headerText)
                    .SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN))
                    .SetFontSize(18)
                    .SetBold()
                    .SetFontColor(ColorConstants.BLACK);
        }

        private Table CreateTourTable(List<string> colsName, TourSchemaWithLog tourSchema)
        {
            var table = new Table(UnitValue.CreatePercentArray(7)).UseAllAvailableWidth();

            table.SetFontSize(14).SetBackgroundColor(ColorConstants.WHITE);

            table = AddTableHeadersInTable(table, colsName);

            table = AddRowsInTourTable(table, tourSchema);

            return table;
        }

        private Table CreateTourLogTable(List<string> colsName, List<TourLogSchema> tourlogs)
        {
            var table = new Table(UnitValue.CreatePercentArray(5)).UseAllAvailableWidth();

            table.SetFontSize(10).SetBackgroundColor(ColorConstants.WHITE);

            table = AddTableHeadersInTable(table, colsName);

            table = AddRowsInTourLogTable(table, tourlogs);

            return table;
        }

        private Table AddRowsInTourLogTable(Table table, List<TourLogSchema> tourlogs)
        {
            foreach (var item in tourlogs)
            {
                table.AddCell(item.DateTime.ToString());
                table.AddCell(item.Comment.ToString());
                table.AddCell(item.TotalDuration.ToString());
                table.AddCell(item.Difficulty.ToString());
                table.AddCell(item.Rating.ToString());
            }

            return table;
        }

        private Table AddRowsInTourTable(Table table, TourSchemaWithLog tourSchema)
        {
            table.AddCell(tourSchema.Name);
            table.AddCell(tourSchema.From);
            table.AddCell(tourSchema.To);
            table.AddCell(tourSchema.TourDescription);
            table.AddCell(tourSchema.Distance.ToString());
            table.AddCell(tourSchema.TransportType.ToString());
            table.AddCell(tourSchema.EstimatedTime.ToString());

            return table;
        }

        private Cell GetHeaderCell(string name)
        {
            return new Cell().Add(new Paragraph(name)).SetBold().SetBackgroundColor(ColorConstants.LIGHT_GRAY);
        }

        private Table AddTableHeadersInTable(Table table, List<string> colNames)
        {
            foreach (string name in colNames)
            {
                table.AddHeaderCell(this.GetHeaderCell(name));
            }

            return table;
        }

        public override bool Generate(TourSchemaWithLog reportData)
        {
            if (!File.Exists(this.FilePath))
            {
                var mainHeader = this.CreateHeader("Tour planer Report");

                this._document.Add(mainHeader);

                var tourTablecols = new List<string> { "Name", "From", "To", "Description", "Distance", "Transport Type", "Estimated time" };

                var tourLogTablecols = new List<string> { "Datetime", "Comment", "Duration", "Difficulty", "Rating" };

                var tourTable = this.CreateTourTable(tourTablecols, reportData);

                this._document.Add(tourTable);

                this._document.Add(new AreaBreak());

                var tourLogTable = this.CreateTourLogTable(tourLogTablecols, reportData.Logs);

                this._document.Add(tourLogTable);

                this._document.Close();

                return true;
            }

            return false;
        }
    }
}
