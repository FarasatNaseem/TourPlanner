using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.FileSystem.Handler;
using TourPlanner.FileSystem.JSON;
using TourPlanner.Model;
using TourPlanner.Model.DbSchema;
using TourPlanner.Server.DL.DB;

namespace TourPlanner.Server.BL
{
    public class ServerOperationExecuter
    {
        private readonly IFileHandler _fileHandler;
        private readonly Database _tourPlannerDatabase;
        private string connectionString;

        public ServerOperationExecuter()
        {
            this._fileHandler = new JSONFileHandler();
            this.connectionString = this._fileHandler.Read(this._fileHandler.Read(@"C:\Users\Privat\source\repos\TourPlanner\TourPlanner.Server.DL\Config\TourPlannerDbConfig.json"));
            this._tourPlannerDatabase = new Database(this.connectionString);
        }

        public (bool, string) AddTourLog(string jsonTourLogData)
        {
            var tourLog = JsonConvert.DeserializeObject<TourLogSchema>(jsonTourLogData);
           
            var duration= JObject.Parse(jsonTourLogData)["TotalDuration"];
            tourLog.TotalDuration = TimeSpan.Parse(duration.ToString());

            return tourLog == null ? (false, null) : this._tourPlannerDatabase.AddTourLog(tourLog);
        }

        public (bool, string) AddTour(string jsonTourData)
        {
            var tour = JsonConvert.DeserializeObject<TourSchemaWithoutLog>(jsonTourData);

            return tour == null ? (false, null) : this._tourPlannerDatabase.AddTour(tour);
        }

        public (List<TourSchemaWithoutLog>, string) GetAllTourWithoutLogs()
        {
            return this._tourPlannerDatabase.GetAllTour();
        }

        public (List<TourSchemaWithLog>, string) GetAllTourWithLogs()
        {
            return this._tourPlannerDatabase.GetAllTourWithLogs();
        }
    }
}
