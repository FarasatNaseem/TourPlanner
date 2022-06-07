namespace MapQuestApi.Image
{
    using Logging;
    using Microsoft.Extensions.Logging;
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TourPlanner.Model;

    public class RouteImageApiService : AbstractMapQuestApiService<RouteImageApiResponse>
    {

        private readonly ILogger logger = Logger.CreateLogger<AbstractMapQuestApiService<RouteImageApiResponse>>();
        private RouteImageApiRequest _routeImageApiRequest;
        private string _url;
        private string _filePath;
        public RouteImageApiService(RouteImageApiRequest routeImageApiRequest)
        {
            this._routeImageApiRequest = routeImageApiRequest;
            this._url = $"https://open.mapquestapi.com/staticmap/v5/map?start={this._routeImageApiRequest.From}&end={this._routeImageApiRequest.To}&size={this._routeImageApiRequest.ImageHeight},{this._routeImageApiRequest.ImageWidth}@2x&key={this._routeImageApiRequest.Key.ApiKey}";
            this._filePath = Constraint.BASEURL + "TourPlanner.BL\\Assets\\" + this._routeImageApiRequest.From + this._routeImageApiRequest.To + ".png";
        }

        public override async Task<RouteImageApiResponse> Get()
        {
            try
            {
                using (this.HttpClient)
                {
                    using (HttpResponseMessage response = await this.HttpClient.GetAsync(this._url, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))

                    using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                    {
                        using (Stream streamToWriteTo = File.Open(this._filePath, FileMode.Create))
                        {
                            await streamToReadFrom.CopyToAsync(streamToWriteTo);
                        }
                    }
                }
                logger.Log(LogLevel.Information, "Image has been fetched.");

                return new RouteImageApiResponse(this._filePath, true);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex.StackTrace);

                return new RouteImageApiResponse("Cant fetch image from given URL", false);
            }
        }
    }
}
