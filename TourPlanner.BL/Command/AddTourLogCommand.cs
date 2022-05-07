using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.Logic;
using TourPlanner.Client.BL.ViewModel;
using TourPlanner.Model;

namespace TourPlanner.Client.BL.Command
{
    public class AddTourLogCommand : ITourPlannerCommand
    {
        private readonly AddTourLogViewModel _addTourLogViewModel;
        private IOperationExecuter<TourLog> _addNewTourLogOperationExecuter;

        public AddTourLogCommand(AddTourLogViewModel addTourLogViewModel)
        {
            this._addTourLogViewModel = addTourLogViewModel;
            this._addNewTourLogOperationExecuter = new AddNewTourLogOperationExecuter(this._addTourLogViewModel);
        }

        public void Execute(object commandParamenter)
        {
            var rand = new Random();
            int id = rand.Next(1, 3);
            var tourLog = new TourLog(/*this._addTourLogViewModel.TourId*/id, this._addTourLogViewModel.DateTime, this._addTourLogViewModel.Comment, this._addTourLogViewModel.Difficulty, this._addTourLogViewModel.TotalDuration, this._addTourLogViewModel.Rating);
            this._addNewTourLogOperationExecuter.Execute(tourLog);
        }
    }
}