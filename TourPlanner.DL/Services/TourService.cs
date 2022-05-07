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
        /* Functions:
         * 1) GetAllTours()
         * 2) DeleteTour(int id)
         * 3) UpdateTour(int id, list<Tour> updatedData)
         * 4) CreateTour()
         */


        public void SaveImage(string imageUrl, string filename, ImageFormat format)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageUrl);
            Bitmap bitmap; bitmap = new Bitmap(stream);

            if (bitmap != null)
            {
                bitmap.Save(filename, format);
            }

            stream.Flush();
            stream.Close();
            client.Dispose();
        }


        public override async Task<GenericApiResponse> Create(object dataToStoreInDB)
        {
            Tour tour = (Tour)dataToStoreInDB;

            // Download Route image.
            //string url = $"https://open.mapquestapi.com/staticmap/v5/map?start={tour.From}&end={tour.To}&size=600,400@2x&key=kmzagLUfOds5SBeFiVMOjG1wnCjXWVnm";
            //string outputPath = @"C:\Users\Privat\source\repos\TourPlanner\TourPlanner.BL\Assets\" + tour.From + tour.To + ".png";
            //this.SaveImage(url, outputPath, ImageFormat.Png);

            tour.RouteImage = "Some path";

            var apiResponse = await Task.Run(()=>this.HttpClient.PostAsync($"https://localhost:5001/Tour",
                   new StringContent(
                       JsonConvert.SerializeObject(tour),
                       Encoding.Default,
                       "application/json"
                   ))).ConfigureAwait(false);

            if (apiResponse.IsSuccessStatusCode)
            {
                var data = await Task.Run(() => apiResponse.Content.ReadAsStringAsync()).ConfigureAwait(false);
                            

                return new GenericApiResponse("New Tour is created", null, true);
            }
         
            return new GenericApiResponse("New Tour cant be created", null, false);
        }

        public override async Task<GenericApiResponse> ReadAll()
        {
            var apiResponse = await Task.Run(() => this.HttpClient.GetAsync("https://localhost:5001/Tour")).ConfigureAwait(false);

            if (apiResponse.IsSuccessStatusCode)
            {
                var data = await Task.Run(() => apiResponse.Content.ReadAsStringAsync()).ConfigureAwait(false);

                var tours = JsonConvert.DeserializeObject<List<TourSchemaWithLog>>(data.ToString());

                return new GenericApiResponse("Data fetched", tours, true);
            }

            return new GenericApiResponse("Error", null, false);
        }

        public override Task<GenericApiResponse> Delete(int idOfData)
        {
            throw new NotImplementedException();
        }

        public override Task<GenericApiResponse> Read(int id)
        {
            throw new NotImplementedException();
        }
        
        public override Task<GenericApiResponse> Update(object listOfUpdatedData)
        {
            throw new NotImplementedException();
        }
    }
}
