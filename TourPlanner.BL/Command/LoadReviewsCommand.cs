using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.Logic;
using TourPlanner.Client.BL.ViewModel;

namespace TourPlanner.Client.BL.Command
{
    public class LoadReviewsCommand : ITourPlannerCommand
    {
        private IOperationExecuter<object> _loadReviewOperationExecuter;
        private readonly ReviewsViewModel _reviewViewModel;
        public LoadReviewsCommand(ReviewsViewModel reviewViewModel)
        {
            this._loadReviewOperationExecuter = new LoadReviewsOperationExecuter(reviewViewModel);
        }

        public void Execute(object commandParamenter)
        {
            this._loadReviewOperationExecuter.Execute(null);
        }
    }
}