using MapQuestApi;
using MapQuestApi.Image;
using MapQuestApi.Route;
using Nito.AsyncEx;
using TourPlanner.Client.BL.Authenticator;
using TourPlanner.Client.BL.ViewModel;
using TourPlanner.Client.DL.Responses;
using TourPlanner.Client.DL.SingletonPattern;
using TourPlanner.Model;

namespace TourPlanner.Client.BL.Logic
{
    public class AddNewTourOperationExecuter : IOperationExecuter<Tour>
    {
        private readonly AddTourViewModel _addTourViewModel;
        private AbstractMapQuestApiService<RouteApiResponse> _abstractMapQuestRouteApiService;
        private AbstractMapQuestApiService<RouteImageApiResponse> _abstractMapQuestImageApiService;

        private readonly ITourPlannerAuthenticationService<TourAuthenticationServiceMessage, Tour> _tourAuthenticationService;

        public AddNewTourOperationExecuter(AddTourViewModel addTourViewModel)
        {
            this._addTourViewModel = addTourViewModel;
            this._tourAuthenticationService = new TourAuthenticationService();
        }

        public void Execute(Tour tour)
        {
            var message = this._tourAuthenticationService.Authenticate(tour);

            switch (message)
            {
                case TourAuthenticationServiceMessage.Success:

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
                    GenericApiResponse response = AsyncContext.Run(() => TourPlannerApiServiceProvider.TourService.Create(tour));

                    // show success message.
                    this._addTourViewModel.Message = response.ResponseMessage;

                    break;
                case TourAuthenticationServiceMessage.Error:

                    // show error message.
                    this._addTourViewModel.Message = "Due to some error new tour cant be created!";
                    
                    break;
                case TourAuthenticationServiceMessage.None:
                    break;
                default:
                    break;
            }
        }
    }
}
