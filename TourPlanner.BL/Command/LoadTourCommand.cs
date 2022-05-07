using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.Logic;
using TourPlanner.Client.BL.ViewModel;

namespace TourPlanner.Client.BL.Command
{
    public class LoadTourCommand : ITourPlannerCommand
    {
        private IOperationExecuter<object> _loadTourOperationExecuter;
        private readonly TourViewModel _tourViewModel;
        public LoadTourCommand(TourViewModel tourViewModel)
        {
            this._tourViewModel = tourViewModel;
            this._loadTourOperationExecuter = new LoadTourOperationExecuter(tourViewModel);
        }

        public void Execute(object commandParamenter)
        {
            this._loadTourOperationExecuter.Execute(null);
        }
    }
}
