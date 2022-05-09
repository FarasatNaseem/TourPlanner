namespace MapQuestApi.Route
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Threading.Tasks;

    public class RouteApiService : AbstractMapQuestApiService<RouteApiResponse>
    {
        private RouteApiRequest _routeApiRequest;
        private string _url;
        public RouteApiService(RouteApiRequest routeApiRequest)
        {
            this._routeApiRequest = routeApiRequest;
            this._url = $"http://www.mapquestapi.com/directions/v2/route?key={this._routeApiRequest.Key.ApiKey}&from={this._routeApiRequest.From}&to={this._routeApiRequest.To}";
        }

        public override async Task<RouteApiResponse> Get()
        {
            double distance = 0.0;
            var time = new TimeSpan();

            var apiResult = await Task.Run(() => this.HttpClient.GetAsync(this._url)).ConfigureAwait(false);

            if (apiResult.IsSuccessStatusCode)
            {
                var response = await Task.Run(() => apiResult.Content.ReadAsStringAsync());

                var parsedJSON = JObject.Parse(response);

                distance = Convert.ToDouble(parsedJSON["route"]["distance"].ToString());

                time = TimeSpan.Parse(parsedJSON["route"]["formattedTime"].ToString());

                return new RouteApiResponse(distance, time, true);
            }

            return null;
        }
    }
}
