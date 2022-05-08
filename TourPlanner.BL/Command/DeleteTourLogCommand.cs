using System.Collections.ObjectModel;
using TourPlanner.Client.BL.Logic;
using TourPlanner.Client.BL.Wrapper;

namespace TourPlanner.Client.BL.Command
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
