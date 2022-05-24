using Newtonsoft.Json;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.DL.Responses;
using TourPlanner.Client.DL.SingletonPattern;
using TourPlanner.FileSystem.Handler;
using TourPlanner.FileSystem.JSON;
using TourPlanner.Model;
using TourPlanner.Model.DbSchema;
using Xceed.Wpf.Toolkit;

namespace TourPlanner.Client.BL.Logic
{
    public class ExportTourCommandExecuter : IOperationExecuter<object>
    {
        private IFileWriter _jsonFileWriter;

        public ExportTourCommandExecuter()
        {
            this._jsonFileWriter = new JSONFileHandler();
        }

        public void Execute(object parameter)
        {
            try
            {
                GenericApiResponse response = AsyncContext.Run(() => TourPlannerApiServiceProvider.TourService.ReadAll());

                if (response.IsCorrectlyResponded)
                {
                    var jsonFileWriterResponse = AsyncContext.Run(() => this._jsonFileWriter.Write(Constraint.BASEURL + "TourPlanner.Server.DL\\JsonDb\\Tours.json", JsonConvert.SerializeObject((List<TourSchemaWithLog>)response.Data)));
                }
            }
            catch (Exception ex)
            {
                // Log error
            }
        }
    }
}
