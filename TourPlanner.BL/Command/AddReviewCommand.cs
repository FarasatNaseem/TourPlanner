using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.Logic;
using TourPlanner.Client.BL.ViewModel;
using TourPlanner.Model;

namespace TourPlanner.Client.BL.Command
{
    public class AddReviewCommand : ITourPlannerCommand
    {
        private AddReviewViewModel addReviewViewModel;
        private IOperationExecuter<Review> _addReviewOperationExecuter;

        public AddReviewCommand(AddReviewViewModel addReviewViewModel)
        {
            this.addReviewViewModel = addReviewViewModel;
            this._addReviewOperationExecuter = new AddReviewOperationExecuter(addReviewViewModel);
        }

        public void Execute(object commandParameter)
        {
            var review = new Review(this.addReviewViewModel.Name, this.addReviewViewModel.Feedback);
            this._addReviewOperationExecuter.Execute(review);
        }
    }
}