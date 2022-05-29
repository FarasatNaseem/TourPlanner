using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.Logic;
using TourPlanner.Client.BL.ViewModel;

namespace TourPlanner.Client.BL.Command
{
    public class FetchSpecificTourCommand : ITourPlannerCommand
    {
        private readonly IOperationExecuter<int> _fetchSpecificTourOperationExecuter;
        public FetchSpecificTourCommand(UpdateTourViewModel updateTourViewModel)
        {
            this._fetchSpecificTourOperationExecuter = new FetchSpecificTourOperationExecuter(updateTourViewModel);
        }

        public void Execute(object commandParameter)
        {
            this._fetchSpecificTourOperationExecuter.Execute((int)commandParameter);
        }
    }
}
