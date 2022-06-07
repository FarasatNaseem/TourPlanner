namespace TourPlanner.Client.BL.Authenticator
{
    using Newtonsoft.Json;
    using Nito.AsyncEx;
    using System.Collections.Generic;
    using TourPlanner.FileSystem.Handler;
    using TourPlanner.FileSystem.JSON;
    using TourPlanner.Model;
    public enum TourAuthenticationServiceMessage
    {
        Success,
        NameIsEmpty,
        FromIsEmpty,
        ToIsEmpty,
        DescriptionIsEmpty,
        Error,
        None
    }

    public class TourAuthenticationService : ITourPlannerAuthenticationService<TourAuthenticationServiceMessage, Tour>
    {
        public TourAuthenticationServiceMessage Authenticate(Tour tour)
        {
            if (!this.IsOK(tour) || !this.AreFromAndToDifferent(tour.From, tour.To) || !this.IsCityNameCorrect(tour.From) || !this.IsCityNameCorrect(tour.To))
            {
                return TourAuthenticationServiceMessage.Error;
            }

            return TourAuthenticationServiceMessage.Success;
        }

        private bool IsOK(Tour tour)
        {
            return !(string.IsNullOrEmpty(tour.Name) && string.IsNullOrEmpty(tour.From) && string.IsNullOrEmpty(tour.To) && string.IsNullOrEmpty(tour.TourDescription));
        }

        private bool AreFromAndToDifferent(string from, string to)
        {
            return from != to ? true : false;
        }

        private bool IsCityNameCorrect(string cityName)
        {
            IFileHandler handler = new JSONFileHandler();
            var jsonFileReaderResponse = AsyncContext.Run(() => handler.Read(Constraint.BASEURL + "TourPlanner.Server.DL\\JsonDb\\city.json"));
            var cities = JsonConvert.DeserializeObject<List<City>>(jsonFileReaderResponse.Item1);

            foreach(var city in cities)
            {
                if (city.Name == cityName)
                    return true;
            }

            return false;
        }
    }
}
