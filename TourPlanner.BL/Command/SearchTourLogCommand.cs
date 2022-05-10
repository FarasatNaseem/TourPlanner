using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.Logic;
using TourPlanner.Client.BL.Wrapper;

namespace TourPlanner.Client.BL.Command
{
    public class SearchTourLogCommand : ITourPlannerCommand
    {
        private ObservableCollection<TourLogWrapper> _tourLogs;
        private IOperationExecuter<ArrayList> _searchTourLogOperationExecuter;
        private int id = 0;

        public SearchTourLogCommand(ObservableCollection<TourLogWrapper> tourLogs)
        {
            this._tourLogs = tourLogs;
            this._searchTourLogOperationExecuter = new SearchTourLogOperationExecuter(this._tourLogs);
        }

        public void Execute(object commandParameter)
        {
            if(this.id < 1 && this._tourLogs == null)
            {
                return;
            }

            string someText = commandParameter.ToString();

            if (this._tourLogs.Count != 0)
                id = this._tourLogs[0].TourID;


            var paramsList = new ArrayList();
            paramsList.Add(someText);
            paramsList.Add(id);

            this._searchTourLogOperationExecuter.Execute(paramsList);
        }
    }
}
