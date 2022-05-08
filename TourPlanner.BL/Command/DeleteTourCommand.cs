using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.Logic;
using TourPlanner.Client.BL.ViewModel;
using TourPlanner.Client.BL.Wrapper;

namespace TourPlanner.Client.BL.Command
{
    public class DeleteTourCommand : ITourPlannerCommand
    {
        private ObservableCollection<TourWrapper> _tours;
        private IOperationExecuter<int> _deleteTourOperationExecuter;
        private BaseViewModel _tourLogViewModel;
        public DeleteTourCommand(ObservableCollection<TourWrapper> tours, BaseViewModel tourLogViewModel)
        {
            this._tours = tours;
            this._tourLogViewModel = tourLogViewModel;
            this._deleteTourOperationExecuter = new DeleteTourOperationExecuter(this._tours, this._tourLogViewModel);

        }
        public void Execute(object commandParameter)
        {
            this._deleteTourOperationExecuter.Execute((int)commandParameter);
        }
    }
}