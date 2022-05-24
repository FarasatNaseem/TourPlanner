using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.ViewModel;
using TourPlanner.Client.BL.Wrapper;

namespace TourPlanner.Client.BL.Command
{
    public class UpdateViewCommand : ITourPlannerCommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public void Execute(object commandParameter)
        {
            if (commandParameter.ToString() == "Add Tour")
            {
                viewModel.SelectedViewModel = new AddTourViewModel(viewModel);
            }
            else if (commandParameter is TourLogViewModel)
            {
                int tourId = ((TourLogViewModel)commandParameter).Tours[0].ID;
                viewModel.SelectedViewModel = new AddTourLogViewModel(viewModel, tourId);
            }
            else if (commandParameter is int)
            {
                viewModel.SelectedViewModel = new UpdateTourViewModel(viewModel, (int)commandParameter);
            }
            else if (commandParameter.ToString() == "Go Home")
            {
                viewModel.SelectedViewModel = new HomeViewModel(viewModel);
            }
            else if (commandParameter is TourLogWrapper)
            {
                var tourLog = (TourLogWrapper)commandParameter;
                viewModel.SelectedViewModel = new UpdateTourLogViewModel(viewModel, tourLog.Id, tourLog.TourID);
            }
            
        }
    }
}
