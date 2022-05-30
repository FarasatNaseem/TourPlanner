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
    public class ReviewService : AbstractService
    {
        public override async Task<GenericApiResponse> Create(object dataToStoreInDB)
        {
            var review = (Review)dataToStoreInDB;

            var apiResponse = await Task.Run(() => this.HttpClient.PostAsync($"https://localhost:5001/Review",
                   new StringContent(
                       JsonConvert.SerializeObject(review),
                       Encoding.Default,
                       "application/json"
                   ))).ConfigureAwait(false);

            if (apiResponse.IsSuccessStatusCode)
            {
                var data = await Task.Run(() => apiResponse.Content.ReadAsStringAsync()).ConfigureAwait(false);

                //logger.Log(LogLevel.Information, "Tour is created successfully");

                return new GenericApiResponse("New Review is created", null, true);
            }

            //logger.Log(LogLevel.Error, "Due to some error new tour cant be created.");

            return new GenericApiResponse("New Reviww cant be created", null, false);
        }

        public override Task<GenericApiResponse> Delete(int idOfData)
        {
            throw new NotImplementedException();
        }

        public override Task<GenericApiResponse> Read(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<GenericApiResponse> ReadAll()
        {
            var apiResponse = await Task.Run(() => this.HttpClient.GetAsync("https://localhost:5001/Review")).ConfigureAwait(false);

            if (apiResponse.IsSuccessStatusCode)
            {
                var data = await Task.Run(() => apiResponse.Content.ReadAsStringAsync()).ConfigureAwait(false);

                var reviews = JsonConvert.DeserializeObject<List<ReviewSchema>>(data.ToString());

                //logger.Log(LogLevel.Information, "Tours data are successfully fetched");

                return new GenericApiResponse("Data fetched", reviews, true);
            }

            //logger.Log(LogLevel.Error, "Due to some error new tours data cant be fetched.");

            return new GenericApiResponse("Error", null, false);
        }

        public override Task<GenericApiResponse> ReadLike(string someText)
        {
            throw new NotImplementedException();
        }

        public override Task<GenericApiResponse> ReadLike(string someText, int id = 0)
        {
            throw new NotImplementedException();
        }

        public override Task<GenericApiResponse> Update(object listOfUpdatedData)
        {
            throw new NotImplementedException();
        }
    }
}
