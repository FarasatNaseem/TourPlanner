using Microsoft.Extensions.Configuration;
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

            IConfiguration config = new ConfigurationBuilder()
               .AddJsonFile(Constraint.BASEURL + "TourPlanner.Server.DL\\Config\\TourPlannerDbConfig.json", false, true)
             .Build();


            this._tourPlannerDatabase = new Database(config);
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


        public (bool, string) AddReview(string jsonTourData)
        {
            var review = JsonConvert.DeserializeObject<ReviewSchema>(jsonTourData);

            return review == null ? (false, null) : this._tourPlannerDatabase.AddReview(review);
        }

        public(bool, string) StoreBackup(string jsonToursWithLogs)
        {
            var tours = JsonConvert.DeserializeObject<List<TourSchemaWithLog>>(jsonToursWithLogs);
            return this._tourPlannerDatabase.StoreBackup(tours);
        }

        public (List<ReviewSchema>, string) GetAllReview()
        {
            return this._tourPlannerDatabase.GetAllReview();
        }

        public (List<TourSchemaWithoutLog>, string) GetAllTourWithoutLogs()
        {
            return this._tourPlannerDatabase.GetAllTourWithoutLog();
        }

        public (TourSchemaWithoutLog, string) GetTourById(int id)
        {
            return this._tourPlannerDatabase.GetTourById(id);
        }

        public (TourLogSchema, string) GetTourLogById(int id)
        {
            return this._tourPlannerDatabase.GetTourLogByID(id);
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
