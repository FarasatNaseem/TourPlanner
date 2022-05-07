namespace TourPlanner.Client.BL.Command
{
    using System;
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
            Tour tour = new Tour(3, this._addTourViewModel.Name, this._addTourViewModel.From, this._addTourViewModel.To, this._addTourViewModel.Description, TransportType.Bike, 2, "Image", new TimeSpan(), null);
            this._addNewTourOperationExecuter.Execute(tour);
        }
    }
}