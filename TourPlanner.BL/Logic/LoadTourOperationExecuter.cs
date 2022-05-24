using Newtonsoft.Json;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.ViewModel;
using TourPlanner.Client.BL.Wrapper;
using TourPlanner.Client.DL.Responses;
using TourPlanner.Client.DL.SingletonPattern;
using TourPlanner.Model;
using TourPlanner.Model.DbSchema;

namespace TourPlanner.Client.BL.Logic
{
    public class LoadTourOperationExecuter : IOperationExecuter<object>
    {
        private readonly TourViewModel _tourViewModel;

        public LoadTourOperationExecuter(TourViewModel tourViewModel)
        {
            _tourViewModel = tourViewModel;
        }

        public void Execute(object parameter)
        {
            try
            {
                GenericApiResponse response = AsyncContext.Run(() => TourPlannerApiServiceProvider.TourService.ReadAll());

                this._tourViewModel.Tours.Clear();

                var logs = new List<TourLog>();

                foreach (var tour in (List<TourSchemaWithLog>)response.Data)
                {
                    logs.Clear();

                    foreach (var log in tour.Logs)
                    {
                        logs.Add(new TourLog(log.Id, log.TourId, log.DateTime, log.Comment, log.Difficulty, log.TotalDuration, log.Rating));
                    }

                    this._tourViewModel.Tours.Add(new TourWrapper(new Tour(tour.Id, tour.Name, tour.From, tour.To, tour.TourDescription, tour.TransportType, tour.Distance, tour.RouteImage, tour.EstimatedTime, logs)));
                }
            }
            catch (Exception)
            {
            }
        }
    }
}