namespace TourPlanner.Client.BL.Command
{
    using System.Collections.ObjectModel;
    using TourPlanner.Client.BL.Logic;
    using TourPlanner.Client.BL.ViewModel;
    using TourPlanner.Client.BL.Wrapper;
    public class ShowTourLogCommand : ITourPlannerCommand
    {
        private readonly BaseViewModel _tourLogViewModel;
        private ObservableCollection<TourWrapper> _tours;
        private IOperationExecuter<int> _showTourLogOperationExecuter;
        public ShowTourLogCommand(BaseViewModel tourLogViewModel, ObservableCollection<TourWrapper> tours)
        {
            this._tourLogViewModel = tourLogViewModel;
            this._tours = tours;
            this._showTourLogOperationExecuter = new ShowTourLogOperationExecuter(this._tourLogViewModel, this._tours);

        }
        public void Execute(object commandParameter)
        {
            this._showTourLogOperationExecuter.Execute((int)commandParameter);
        }
    }
}
