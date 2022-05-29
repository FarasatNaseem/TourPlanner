using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.Logic;
using TourPlanner.Client.BL.ViewModel;

namespace TourPlanner.Client.BL.Command
{
    public class FetchSpecificTourLogCommand : ITourPlannerCommand
    {
        private readonly IOperationExecuter<int> _fetchSpecificTourLogOperationExecuter;
        public FetchSpecificTourLogCommand(UpdateTourLogViewModel updateTourLogViewModel)
        {
            this._fetchSpecificTourLogOperationExecuter = new FetchSpecificTourLogOperationExecuter(updateTourLogViewModel);
        }

        public void Execute(object commandParameter)
        {
            this._fetchSpecificTourLogOperationExecuter.Execute((int)commandParameter);
        }
    }
}
