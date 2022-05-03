namespace TourPlanner.Client.BL.Command
{
    using TourPlanner.Client.BL.Authenticator;
    using TourPlanner.Client.BL.Logic;
    using TourPlanner.Client.BL.ViewModel;
    using TourPlanner.Model;

    public class AddTourCommand : ITourPlannerCommand
    {
        private readonly AddTourViewModel _addTourViewModel;
        private IOperationExecuter<Tour> _addNewTourOperationExecuter;
        public AddTourCommand(AddTourViewModel addTourViewModel)
        {
            this._addTourViewModel = addTourViewModel;
            this._addNewTourOperationExecuter = new AddNewTourOperationExecuter(addTourViewModel);
        }

        public void Execute(object commandParamenter)
        {
            var tour = new Tour(this._addTourViewModel.Name, this._addTourViewModel.From, this._addTourViewModel.To, this._addTourViewModel.Description, TransportType.Bike);
            this._addNewTourOperationExecuter.Execute(tour);
        }
    }
}