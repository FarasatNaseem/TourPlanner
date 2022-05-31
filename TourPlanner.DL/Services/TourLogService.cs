using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.DL.Responses;
using TourPlanner.Model;
using TourPlanner.Model.DbSchema;

namespace TourPlanner.Client.DL.Services
{
    public class TourLogService : AbstractService
    {
        public override async Task<GenericApiResponse> Create(object dataToStoreInDB)
        {
            var tourLog = (TourLog)dataToStoreInDB;

            var apiResponse = await this.HttpClient.PostAsync($"https://localhost:5001/TourLog",
                    new StringContent(
                        JsonConvert.SerializeObject(tourLog),
                        Encoding.Default,
                        "application/json"
                    ));

            if (apiResponse.IsSuccessStatusCode)
            {
                var data = await Task.Run(() => apiResponse.Content.ReadAsStringAsync()).ConfigureAwait(false);


                return new GenericApiResponse("New Tour Log is created", null, true);
            }

            return new GenericApiResponse("New Tour Log cant be created", null, false);
        }

        public override async Task<GenericApiResponse> Delete(int idOfData)
        {
            var apiResponse = await Task.Run(() => this.HttpClient.DeleteAsync("https://localhost:5001/TourLog/" + idOfData)).ConfigureAwait(false);

            if (apiResponse.IsSuccessStatusCode)
            {
                var data = await Task.Run(() => apiResponse.Content.ReadAsStringAsync()).ConfigureAwait(false);

                return new GenericApiResponse("Tour log is deleted", null, true);
            }

            return new GenericApiResponse("Error", null, false);
        }

        public override Task<GenericApiResponse> Import(object dataToStoreInDB)
        {
            throw new NotImplementedException();
        }

        public override async Task<GenericApiResponse> Read(int id)
        {
            var apiResponse = await Task.Run(() => this.HttpClient.GetAsync($"https://localhost:5001/TourLog/{id}")).ConfigureAwait(false);

            if (apiResponse.IsSuccessStatusCode)
            {
                var data = await Task.Run(() => apiResponse.Content.ReadAsStringAsync()).ConfigureAwait(false);

                var tour = JsonConvert.DeserializeObject<TourLogSchema>(data.ToString());

                //logger.Log(LogLevel.Information, "Tours data are successfully fetched");

                return new GenericApiResponse("Data fetched", tour, true);
            }

            //logger.Log(LogLevel.Error, $"Due to some error tour data with id {id} can't be fetched.");

            return new GenericApiResponse("Error", null, false);
        }

        public override Task<GenericApiResponse> ReadAll()
        {
            throw new NotImplementedException();
        }

        public override async Task<GenericApiResponse> ReadLike(string someText, int id)
        {
            if(someText.Length == 0)
            {
                someText = "empty";
            }

            HttpResponseMessage apiResponse = await Task.Run(() => this.HttpClient.GetAsync($"https://localhost:5001/TourLog/{someText}/{id}")).ConfigureAwait(false);

            if (apiResponse.IsSuccessStatusCode)
            {
                var data = await Task.Run(() => apiResponse.Content.ReadAsStringAsync()).ConfigureAwait(false);

                var tourLogs = JsonConvert.DeserializeObject<List<TourLogSchema>>(data.ToString());

                if(tourLogs.Count == 0)
                {
                    return new GenericApiResponse("Data not found", null, true);
                }
                return new GenericApiResponse("Data fetched", tourLogs, true);

                //logger.Log(LogLevel.Information, "Tours data are successfully fetched");
            }

            //logger.Log(LogLevel.Error, "Due to some error new tours data cant be fetched.");

            return new GenericApiResponse("Error", null, false);
        }

        public override Task<GenericApiResponse> ReadLike(string someText)
        {
            throw new NotImplementedException();
        }

        public override async Task<GenericApiResponse> Update(object listOfUpdatedData)
        {
            TourLog tourLog = (TourLog)listOfUpdatedData;

            var apiResponse = await Task.Run(() => this.HttpClient.PutAsync($"https://localhost:5001/TourLog",
                   new StringContent(
                       JsonConvert.SerializeObject(tourLog),
                       Encoding.Default,
                       "application/json"
                   ))).ConfigureAwait(false);

            if (apiResponse.IsSuccessStatusCode)
            {
                var data = await Task.Run(() => apiResponse.Content.ReadAsStringAsync()).ConfigureAwait(false);

                //logger.Log(LogLevel.Information, "Tour is updated successfully");

                return new GenericApiResponse("Tour Log is updated", null, true);
            }

            //logger.Log(LogLevel.Error, "Due to some error new tour cant be updated.");

            return new GenericApiResponse("Tour Log cant be updated", null, false);
        }
    }
}
