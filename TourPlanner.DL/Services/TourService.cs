using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Model;

namespace TourPlanner.Client.DL.Services
{
    public class TourService : IService
    {
        /* Functions:
         * 1) GetAllTours()
         * 2) DeleteTour(int id)
         * 3) UpdateTour(int id, list<Tour> updatedData)
         * 4) CreateTour()
         */

        private HttpClient _clientService;

        public TourService()
        {
            this._clientService = new HttpClient();
        }

        public async Task<(bool, string)> Create(object dataToStoreInDB)
        {
            Tour tour = (Tour)dataToStoreInDB;
            var response = await this._clientService.PostAsync($"url",
                    new StringContent(
                        /*JsonConvert.SerializeObject(tour)*/ " ",
                        Encoding.Default,
                        "application/json"
                    ));

            return (true, "New Tour is created");
        }

        public async Task<(bool, string)> Delete(int idOfData)
        {
            throw new NotImplementedException();
        }

        public async Task<(object, string)> Read(int idOfData)
        {
            throw new NotImplementedException();
        }

        public async Task<(object, string)> ReadAll()
        {
            throw new NotImplementedException();
        }

        public async Task<(bool, string)> Update(object listOfUpdatedData)
        {
            throw new NotImplementedException();
        }
    }
}
