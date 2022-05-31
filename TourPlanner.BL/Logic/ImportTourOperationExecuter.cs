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

namespace TourPlanner.Client.BL.Logic
{
    public class ImportTourOperationExecuter : IOperationExecuter<object>
    {
        private IFileReader _jsonFileReader;

        public ImportTourOperationExecuter()
        {
            this._jsonFileReader = new JSONFileHandler();
        }

        public void Execute(object parameter)
        {
            try
            {
                var jsonFileReaderResponse = AsyncContext.Run(() => this._jsonFileReader.Read(Constraint.BASEURL + "TourPlanner.Server.DL\\JsonDb\\Tours.json"));
                var tours = JsonConvert.DeserializeObject<List<TourSchemaWithLog>>(jsonFileReaderResponse.Item1);
                GenericApiResponse response = AsyncContext.Run(() => TourPlannerApiServiceProvider.TourService.Import(tours));

                if (response.IsCorrectlyResponded)
                {
                }
            }
            catch (Exception ex)
            {
                // Log error
            }
        }
    }
}
