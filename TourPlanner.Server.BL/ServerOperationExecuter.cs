using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nito.AsyncEx;
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
            var fileHandlerResponse = AsyncContext.Run(() => this._fileHandler.Read(@"C:\Users\Privat\TourPlanner\TourPlanner.Server.DL\Config\TourPlannerDbConfig.json"));
            this.connectionString = fileHandlerResponse.Item1;
            this._tourPlannerDatabase = new Database(this.connectionString);
        }

        public (bool, string) AddTourLog(string jsonTourLogData)
        {
            var tourLog = JsonConvert.DeserializeObject<TourLogSchema>(jsonTourLogData);

            var duration = JObject.Parse(jsonTourLogData)["TotalDuration"];
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
            return this._tourPlannerDatabase.GetAllTourWithoutLog();
        }

        public (TourSchemaWithoutLog, string) GetTourById(int id)
        {
            return this._tourPlannerDatabase.GetTourById(id);
        }

        public (bool, string) UpdateTour(string jsonTourData)
        {
            var tourSchema = JsonConvert.DeserializeObject<TourSchemaWithoutLog>(jsonTourData);

            return this._tourPlannerDatabase.UpdateTour(tourSchema);
        }

        public (bool, string) UpdateTourLog(string jsonTourData)
        {
            var tourLogSchema = JsonConvert.DeserializeObject<TourLogSchema>(jsonTourData);

            return this._tourPlannerDatabase.UpdateTourLog(tourLogSchema);
        }

        public (List<TourSchemaWithLog>, string) FilterTours(string someText)
        {
            return this._tourPlannerDatabase.FilterTours(someText);
        }

        public (List<TourLogSchema>, string) FilterTourLogs(string someText, int id)
        {
            return this._tourPlannerDatabase.FilterTourLogs(someText, id);
        }

        public (List<TourSchemaWithLog>, string) GetAllTourWithLogs()
        {
            return this._tourPlannerDatabase.GetAllTourWithLogs();
        }

        public (bool, string) DeleteTourByID(int tourId)
        {
            return this._tourPlannerDatabase.DeleteTourById(tourId);
        }

        public (bool, string) DeleteTourLogByID(int tourId)
        {
            return this._tourPlannerDatabase.DeleteTourLogById(tourId);
        }
    }
}
