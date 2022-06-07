using Logging;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.DL.Responses;
using TourPlanner.Model;
using TourPlanner.Model.DbSchema;

namespace TourPlanner.Client.DL.Services
{
    public class TourService : AbstractService
    {
        /* 
         * Functions to implement:
         * 1) GetAllTours()
         * 2) DeleteTour(int id)
         * 3) UpdateTour(int id, list<Tour> updatedData)
         * 4) CreateTour()
         */

        private readonly ILogger logger = Logger.CreateLogger<AbstractService>();

        public override async Task<GenericApiResponse> Create(object dataToStoreInDB)
        {
            var settings = new Newtonsoft.Json.JsonSerializerSettings();
            // This tells your serializer that multiple references are okay.
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            Tour tour = (Tour)dataToStoreInDB;

          
            var apiResponse = await Task.Run(() => this.HttpClient.PostAsync($"https://localhost:5001/Tour",
                   new StringContent(
                       JsonConvert.SerializeObject(tour, settings),
                       Encoding.Default,
                       "application/json"
                   ))).ConfigureAwait(false);

            if (apiResponse.IsSuccessStatusCode)
            {
                var data = await Task.Run(() => apiResponse.Content.ReadAsStringAsync()).ConfigureAwait(false);

                logger.Log(LogLevel.Information, "Tour is created successfully");

                return new GenericApiResponse($"{data}", null, true);
            }

            logger.Log(LogLevel.Error, "Due to some error new tour cant be created.");

            return new GenericApiResponse("New Tour cant be created", null, false);
        }

        public override async Task<GenericApiResponse> ReadAll()
        {
            var apiResponse = await Task.Run(() => this.HttpClient.GetAsync("https://localhost:5001/Tour")).ConfigureAwait(false);

            if (apiResponse.IsSuccessStatusCode)
            {
                var data = await Task.Run(() => apiResponse.Content.ReadAsStringAsync()).ConfigureAwait(false);

                var tours = JsonConvert.DeserializeObject<List<TourSchemaWithLog>>(data.ToString());
                Console.WriteLine(data.ToString());

                logger.Log(LogLevel.Information, "Tours data are successfully fetched");

                return new GenericApiResponse("Data fetched", tours, true);
            }

            logger.Log(LogLevel.Error, "Due to some error new tours data cant be fetched.");

            return new GenericApiResponse("Error", null, false);
        }

        public override async Task<GenericApiResponse> ReadLike(string someText)
        {
            var apiResponse = await Task.Run(() => this.HttpClient.GetAsync($"https://localhost:5001/Tour/search={someText}")).ConfigureAwait(false);

            if (apiResponse.IsSuccessStatusCode)
            {
                var data = await Task.Run(() => apiResponse.Content.ReadAsStringAsync()).ConfigureAwait(false);

                var tours = JsonConvert.DeserializeObject<List<TourSchemaWithLog>>(data.ToString());

                logger.Log(LogLevel.Information, "Tours data are successfully fetched");

                return new GenericApiResponse("Data fetched", tours, true);
            }

            logger.Log(LogLevel.Error, "Due to some error new tours data cant be fetched.");

            return new GenericApiResponse("Error", null, false);
        }

        public override async Task<GenericApiResponse> Read(int id)
        {
            var apiResponse = await Task.Run(() => this.HttpClient.GetAsync($"https://localhost:5001/Tour/{id}")).ConfigureAwait(false);

            if (apiResponse.IsSuccessStatusCode)
            {
                var data = await Task.Run(() => apiResponse.Content.ReadAsStringAsync()).ConfigureAwait(false);

                var tour = JsonConvert.DeserializeObject<TourSchemaWithoutLog>(data.ToString());

                logger.Log(LogLevel.Information, "Tours data are successfully fetched");

                return new GenericApiResponse("Data fetched", tour, true);
            }

            logger.Log(LogLevel.Error, $"Due to some error tour data with id {id} can't be fetched.");

            return new GenericApiResponse("Error", null, false);
        }

        public override async Task<GenericApiResponse> Delete(int idOfData)
        {
            var apiResponse = await Task.Run(() => this.HttpClient.DeleteAsync("https://localhost:5001/Tour/" + idOfData)).ConfigureAwait(false);

            if (apiResponse.IsSuccessStatusCode)
            {
                var data = await Task.Run(() => apiResponse.Content.ReadAsStringAsync()).ConfigureAwait(false);

                logger.Log(LogLevel.Information, "Tour is now deleted successfully");

                return new GenericApiResponse("Tour is deleted", null, true);
            }

            logger.Log(LogLevel.Error, "Due to some error new tour data cant be deleted.");

            return new GenericApiResponse("Error", null, false);
        }

        public override async Task<GenericApiResponse> Update(object listOfUpdatedData)
        {
            var settings = new Newtonsoft.Json.JsonSerializerSettings();
            // This tells your serializer that multiple references are okay.
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            Tour tour = (Tour)listOfUpdatedData;

            var apiResponse = await Task.Run(() => this.HttpClient.PutAsync($"https://localhost:5001/Tour",
                   new StringContent(
                       JsonConvert.SerializeObject(tour, settings),
                       Encoding.Default,
                       "application/json"
                   ))).ConfigureAwait(false);

            if (apiResponse.IsSuccessStatusCode)
            {
                var data = await Task.Run(() => apiResponse.Content.ReadAsStringAsync()).ConfigureAwait(false);

                logger.Log(LogLevel.Information, "Tour is updated successfully");

                return new GenericApiResponse("Tour is updated", null, true);
            }

            logger.Log(LogLevel.Error, "Due to some error new tour cant be updated.");

            return new GenericApiResponse("Tour cant be updated", null, false);
        }

        public override Task<GenericApiResponse> ReadLike(string someText, int id = 0)
        {
            throw new NotImplementedException();
        }

        public override async Task<GenericApiResponse> Import(object dataToStoreInDB)
        {
            var settings = new Newtonsoft.Json.JsonSerializerSettings();
            // This tells your serializer that multiple references are okay.
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            var tours = (List<TourSchemaWithLog>)dataToStoreInDB;

            var apiResponse = await Task.Run(() => this.HttpClient.PostAsync($"https://localhost:5001/Tour/import",
                   new StringContent(
                       JsonConvert.SerializeObject(tours, settings),
                       Encoding.Default,
                       "application/json"
                   ))).ConfigureAwait(false);

            if (apiResponse.IsSuccessStatusCode)
            {
                var data = await Task.Run(() => apiResponse.Content.ReadAsStringAsync()).ConfigureAwait(false);

                logger.Log(LogLevel.Information, "Tour is created successfully");

                return new GenericApiResponse("New Tour is created", null, true);
            }

            logger.Log(LogLevel.Error, "Due to some error new tour cant be created.");

            return new GenericApiResponse("New Tour cant be created", null, false);
        }
    }
}