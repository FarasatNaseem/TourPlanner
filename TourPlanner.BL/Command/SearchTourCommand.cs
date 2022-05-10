using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.Logic;
using TourPlanner.Client.BL.Wrapper;

namespace TourPlanner.Client.BL.Command
{
    public class SearchTourCommand : ITourPlannerCommand
    {
        private ObservableCollection<TourWrapper> tours;
        private IOperationExecuter<string> _searchTourOperationExecuter;

        public SearchTourCommand(ObservableCollection<TourWrapper> tours)
        {
            this.tours = tours;
            this._searchTourOperationExecuter = new SearchTourOperationExecuter(tours);
        }

        public void Execute(object commandParameter)
        {
            this._searchTourOperationExecuter.Execute(commandParameter.ToString());
        }
    }
}