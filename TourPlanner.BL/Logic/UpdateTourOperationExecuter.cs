using MapQuestApi;
using MapQuestApi.Image;
using MapQuestApi.Route;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.Authenticator;
using TourPlanner.Client.BL.ViewModel;
using TourPlanner.Client.DL.Responses;
using TourPlanner.Client.DL.SingletonPattern;
using TourPlanner.Model;
using TourPlanner.Model.DbSchema;

namespace TourPlanner.Client.BL.Logic
{
    public class UpdateTourOperationExecuter : IOperationExecuter<Tour>
    {
        private readonly UpdateTourViewModel _updateTourViewModel;
        private AbstractMapQuestApiService<RouteApiResponse> _abstractMapQuestRouteApiService;
        private AbstractMapQuestApiService<RouteImageApiResponse> _abstractMapQuestImageApiService;

        private readonly ITourPlannerAuthenticationService<TourAuthenticationServiceMessage, Tour> _tourAuthenticationService;

        public UpdateTourOperationExecuter(UpdateTourViewModel addTourViewModel)
        {
            this._updateTourViewModel = addTourViewModel;
            this._tourAuthenticationService = new TourAuthenticationService();
        }

        public void Execute(Tour tour)
        {
            var message = this._tourAuthenticationService.Authenticate(tour);

            switch (message)
            {
                case TourAuthenticationServiceMessage.Success:

                    // Delete old tour image if from and to dont match.

                    GenericApiResponse readTourResponse = AsyncContext.Run(() => TourPlannerApiServiceProvider.TourService.Read(tour.Id));

                    var oldTourData = (TourSchemaWithoutLog)readTourResponse.Data;


                    if (this.DeleteOldRouteIfExist(oldTourData.From, oldTourData.To))
                    {
                        // Log 
                    }

                    // fetch distance and time.
                    this._abstractMapQuestRouteApiService = new RouteApiService(new RouteApiRequest(tour.From, tour.To));
                    var mapQuestDirectionApiResponse = AsyncContext.Run(() => this._abstractMapQuestRouteApiService.Get());
                    tour.Distance = mapQuestDirectionApiResponse.Distance;
                    tour.EstimatedTime = mapQuestDirectionApiResponse.Time;

                    // fetch image.
                    this._abstractMapQuestImageApiService = new RouteImageApiService(new RouteImageApiRequest("400", "400", tour.From, tour.To));
                    var mapQuestImageApiResponse = AsyncContext.Run(() => this._abstractMapQuestImageApiService.Get());
                    tour.RouteImage = mapQuestImageApiResponse.Path;

                    // send data to database.
                    GenericApiResponse updateTourResponse = AsyncContext.Run(() => TourPlannerApiServiceProvider.TourService.Update(tour));

                    // show success message.
                    this._updateTourViewModel.Message = updateTourResponse.ResponseMessage;

                    break;
                case TourAuthenticationServiceMessage.Error:

                    // show error message.
                    this._updateTourViewModel.Message = "Due to some error new tour cant be updated!";

                    break;
                case TourAuthenticationServiceMessage.None:
                    break;
                default:
                    break;
            }
        }

        public bool IsFromDifferent(string oldFrom, string newFrom)
        {
            return oldFrom == newFrom ? false : true;
        }

        public bool IsToDifferent(string oldTo, string newTo)
        {
            return oldTo == newTo ? false : true;
        }

        private bool DeleteOldRouteIfExist(string from, string to)
        {
            string path = Constraint.BASEURL + "TourPlanner.BL\\Assets\\";

            string file = from + to + ".png";
            
            try
            {
                if (File.Exists(Path.Combine(path, file)))
                {
                    File.Delete(Path.Combine(path, file));

                    return true;
                }

                return false;
            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }

            return false;
        }
    }
}
