using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using TourPlanner.BL.Logic;
using TourPlanner.BL.ViewModel;
using TourPlanner.BL.Wrapper;

namespace TourPlanner.BL.Command
{
    public class DeleteTourLogCommand : ITourPlannerCommand
    {
        private ObservableCollection<TourWrapper> _tours;
        private IOperationExecuter<int> _deleteTourLogOperationExecuter;
        public DeleteTourLogCommand(ObservableCollection<TourWrapper> tours)
        {
            this._tours = tours;
            this._deleteTourLogOperationExecuter = new DeleteTourLogOperationExecuter(this._tours);

        }
        public void Execute(object commandParameter)
        {
              this._deleteTourLogOperationExecuter.Execute((int)commandParameter);
        }
    }
}
