using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.ViewModel;
using TourPlanner.Client.DL.Responses;
using TourPlanner.Client.DL.SingletonPattern;
using TourPlanner.Model;
using TourPlanner.Model.DbSchema;

namespace TourPlanner.Client.BL.Logic
{
    public class LoadReviewsOperationExecuter : IOperationExecuter<object>
    {
        private readonly ReviewsViewModel _reviewsViewModel;

        public LoadReviewsOperationExecuter(ReviewsViewModel reviewsViewModel)
        {
            this._reviewsViewModel = reviewsViewModel;
        }

        public void Execute(object parameter)
        {
            try
            {
                GenericApiResponse response = AsyncContext.Run(() => TourPlannerApiServiceProvider.ReviewService.ReadAll());

                this._reviewsViewModel.Reviews.Clear();

                foreach (var review in (List<ReviewSchema>)response.Data)
                {
                    this._reviewsViewModel.Reviews.Add(new Review(review.Name, review.Feedback));
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
