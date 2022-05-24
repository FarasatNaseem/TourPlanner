using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.Logic;


namespace TourPlanner.Client.BL.Command
{
    public class ExportTourCommand : ITourPlannerCommand
    {
        private IOperationExecuter<object> _exportTourOperationExecuter;

        public ExportTourCommand()
        {
            this._exportTourOperationExecuter = new ExportTourCommandExecuter();
        }

        public void Execute(object commandParameter)
        {
            this._exportTourOperationExecuter.Execute(commandParameter);
        }
    }
}
