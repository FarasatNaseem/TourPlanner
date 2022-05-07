using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.Authenticator;
using TourPlanner.Client.BL.ViewModel;
using TourPlanner.Client.DL.Responses;
using TourPlanner.Client.DL.SingletonPattern;
using TourPlanner.Model;

namespace TourPlanner.Client.BL.Logic
{
    public class AddNewTourLogOperationExecuter : IOperationExecuter<TourLog>
    {
        private readonly AddTourLogViewModel _addTourLogViewModel;
        private readonly ITourPlannerAuthenticationService<TourLogAuthenticationServiceMessage, TourLog> _tourLogAuthenticationService;
        
        public AddNewTourLogOperationExecuter(AddTourLogViewModel addTourLogViewModel)
        {
            this._addTourLogViewModel = addTourLogViewModel;
            this._tourLogAuthenticationService = new TourLogAuthenticationService();
        }
        
        public void Execute(TourLog tourLog)
        {
            var message = this._tourLogAuthenticationService.Authenticate(tourLog);

            switch (message)
            {
                case TourLogAuthenticationServiceMessage.Success:

                    // send data to database.
                    GenericApiResponse response = AsyncContext.Run(() => TourPlannerApiServiceProvider.TourLogService.Create(tourLog));

                    // show success message.
                    this._addTourLogViewModel.Message = response.ResponseMessage;

                    break;
                case TourLogAuthenticationServiceMessage.Error:

                    this._addTourLogViewModel.Message = "Error";
                    
                    break;
                case TourLogAuthenticationServiceMessage.None:
                    break;
                default:
                    break;
            }

        }
    }
}
