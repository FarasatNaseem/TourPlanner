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
    public class UpdateTourLogCommand : ITourPlannerCommand
    {
        private readonly UpdateTourLogViewModel _updateTourLogViewModel;
        private IOperationExecuter<TourLog> _updateTourLogOperationExecuter;

        public UpdateTourLogCommand(UpdateTourLogViewModel updateTourLogViewModel)
        {
            this._updateTourLogViewModel = updateTourLogViewModel;
            this._updateTourLogOperationExecuter = new UpdateTourLogOperationExecuter(updateTourLogViewModel);
        }

        public void Execute(object commandParamenter)
        {
            var tourLog = new TourLog(this._updateTourLogViewModel.TourLogId, this._updateTourLogViewModel.TourId, this._updateTourLogViewModel.DateTime, this._updateTourLogViewModel.Comment, this._updateTourLogViewModel.Difficulty, this._updateTourLogViewModel.TotalDuration, this._updateTourLogViewModel.Rating);
            this._updateTourLogOperationExecuter.Execute(tourLog);
        }
    }
}
