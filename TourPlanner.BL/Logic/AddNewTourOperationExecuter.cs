using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.Authenticator;
using TourPlanner.Client.BL.ViewModel;
using TourPlanner.Client.DL.Services;
using TourPlanner.Client.DL.SingletonPattern;
using TourPlanner.Model;

namespace TourPlanner.Client.BL.Logic
{
    public class AddNewTourOperationExecuter : IOperationExecuter<Tour>
    {
        private readonly AddTourViewModel _addTourViewModel;
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
                    // send data to database.
                    // show success message.
                    TourPlannerApiServiceProvider.TourService.Create(tour);
                    this._addTourViewModel.Message = "Success";
                    break;
                case TourAuthenticationServiceMessage.Error:
                    // show success message.
                    this._addTourViewModel.Message = "Error";
                    break;
                case TourAuthenticationServiceMessage.None:
                    break;
                default:
                    break;
            }
        }
    }
}
