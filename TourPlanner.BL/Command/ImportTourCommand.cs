using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.Logic;

namespace TourPlanner.Client.BL.Command
{
    public class ImportTourCommand : ITourPlannerCommand
    {
        private IOperationExecuter<object> _importTourOperationExecuter;

        public ImportTourCommand()
        {
            this._importTourOperationExecuter = new ImportTourOperationExecuter();
        }

        public void Execute(object commandParameter)
        {
            this._importTourOperationExecuter.Execute(commandParameter);
        }
    }
}
