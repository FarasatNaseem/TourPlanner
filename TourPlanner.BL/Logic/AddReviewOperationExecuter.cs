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
    public class AddReviewOperationExecuter : IOperationExecuter<Review>
    {
        private readonly AddReviewViewModel _addReviewViewModel;
        private readonly ITourPlannerAuthenticationService<ReviewAuthenticationServiceMessage, Review> _reviewAuthenticationService;

        public AddReviewOperationExecuter(AddReviewViewModel addReviewViewModel)
        {
            this._addReviewViewModel = addReviewViewModel;
            this._reviewAuthenticationService = new ReviewAuthenticationService();
        }

        public void Execute(Review review)
        {
            var message = this._reviewAuthenticationService.Authenticate(review);

            switch (message)
            {
                case ReviewAuthenticationServiceMessage.Success:
                    // send data to database.
                    GenericApiResponse response = AsyncContext.Run(() => TourPlannerApiServiceProvider.ReviewService.Create(review));

                    // show success message.
                    this._addReviewViewModel.Message = response.ResponseMessage;
                    break;
                case ReviewAuthenticationServiceMessage.Error:
                    this._addReviewViewModel.Message = "Error";
                    break;
                case ReviewAuthenticationServiceMessage.None:
                    break;
                default:
                    break;
            }
        }
    }
}
