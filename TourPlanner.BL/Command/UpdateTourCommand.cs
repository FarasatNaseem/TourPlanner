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
    public class UpdateTourCommand : ITourPlannerCommand
    {
        private readonly UpdateTourViewModel _updateTourViewModel;
        private IOperationExecuter<Tour> _updateTourOperationExecuter;

        public UpdateTourCommand(UpdateTourViewModel updateTourViewModel)
        {
            this._updateTourViewModel = updateTourViewModel;
            this._updateTourOperationExecuter = new UpdateTourOperationExecuter(updateTourViewModel);
        }

        public void Execute(object commandParamenter)
        {
            Tour tour = new Tour(this._updateTourViewModel.TourId, this._updateTourViewModel.Name, this._updateTourViewModel.From, this._updateTourViewModel.To, this._updateTourViewModel.Description, TransportType.Bike, 2, "Image", new TimeSpan(), null);
            this._updateTourOperationExecuter.Execute(tour);
        }
    }
}
