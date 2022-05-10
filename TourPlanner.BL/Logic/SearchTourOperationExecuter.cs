using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.Wrapper;
using TourPlanner.Client.DL.Responses;
using TourPlanner.Client.DL.SingletonPattern;
using TourPlanner.Model;
using TourPlanner.Model.DbSchema;

namespace TourPlanner.Client.BL.Logic
{
    public class SearchTourOperationExecuter : IOperationExecuter<string>
    {
        private ObservableCollection<TourWrapper> tours;

        public SearchTourOperationExecuter(ObservableCollection<TourWrapper> tours)
        {
            this.tours = tours;
        }

        public void Execute(string parameter)
        {
            GenericApiResponse response = AsyncContext.Run(() => TourPlannerApiServiceProvider.TourService.ReadLike(parameter));

            this.tours.Clear();

            if (response.Data != null)
            {
                var logs = new List<TourLog>();

                foreach (var tour in (List<TourSchemaWithLog>)response.Data)
                {
                    logs.Clear();

                    foreach (var log in tour.Logs)
                    {
                        logs.Add(new TourLog(log.Id, log.TourId, log.DateTime, log.Comment, log.Difficulty, log.TotalDuration, log.Rating));
                    }

                    this.tours.Add(new TourWrapper(new Tour(tour.Id, tour.Name, tour.From, tour.To, tour.TourDescription, tour.TransportType, tour.Distance, tour.RouteImage, tour.EstimatedTime, logs)));
                }
            }
        }
    }
}
