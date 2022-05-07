using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.DL.Responses;
using TourPlanner.Model;

namespace TourPlanner.Client.DL.Services
{
    public class TourLogService : AbstractService
    {
        //public async Task<(bool, string)> Create(object dataToStoreInDB)
        //{
        //    TourLog tourLog = (TourLog)dataToStoreInDB;
        //    var response = await this._clientService.PostAsync($"https://localhost:5001/TourLog",
        //            new StringContent(
        //                JsonConvert.SerializeObject(tourLog),
        //                Encoding.Default,
        //                "application/json"
        //            ));

        //    return (true, "New Tour is created");
        //}

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


        public override Task<GenericApiResponse> Delete(int idOfData)
        {
            throw new NotImplementedException();
        }

        public override Task<GenericApiResponse> Read(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<GenericApiResponse> ReadAll()
        {
            throw new NotImplementedException();
        }

        public override Task<GenericApiResponse> Update(object listOfUpdatedData)
        {
            throw new NotImplementedException();
        }
    }
}
