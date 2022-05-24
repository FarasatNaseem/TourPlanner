using Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.Wrapper;
using TourPlanner.Model.DbSchema;

namespace TourPlanner.Client.BL.Command
{
    public class GenerateNormalReportCommand : ITourPlannerCommand
    {
        private AbstractReportGenerator<TourSchemaWithLog> _abstractReportGenerator;

        public void Execute(object commandParameter)
        {
            var tourWrapper = (TourWrapper)commandParameter;

            var logs = tourWrapper.Logs.ToList();

            var logsSchema = new List<TourLogSchema>();

            foreach (var item in logs)
            {
                logsSchema.Add(new TourLogSchema(item.Id, tourWrapper.ID, item.DateTime, item.Comment, item.Difficulty, item.TotalDuration, item.Rating));
            }

            var tour = new TourSchemaWithLog(tourWrapper.ID, tourWrapper.Name, tourWrapper.From, tourWrapper.To, tourWrapper.Description, tourWrapper.TransportType, tourWrapper.Distance, tourWrapper.RouteImage, tourWrapper.EstimatedTime, logsSchema);

            this._abstractReportGenerator = new PdfReportGenerator($"C:\\Users\\Privat\\TourPlanner\\TourPlanner.BL\\Assets\\Reports\\{tour.Name}.pdf");

            var isGenerated = this._abstractReportGenerator.Generate(tour);
        }
    }
}