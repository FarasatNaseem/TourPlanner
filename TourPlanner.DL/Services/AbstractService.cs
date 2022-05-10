namespace TourPlanner.Client.DL.Services
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using TourPlanner.Client.DL.Responses;

    public abstract class AbstractService : IGetService, IPostService, IPutService, IDeleteService
    {
        public AbstractService()
        {
            this.HttpClient = new HttpClient();
        }

        public HttpClient HttpClient { get; }

        public abstract Task<GenericApiResponse> Create(object dataToStoreInDB);
        public abstract Task<GenericApiResponse> Delete(int idOfData);
        public abstract Task<GenericApiResponse> Read(int id);
        public abstract Task<GenericApiResponse> ReadAll();
        public abstract Task<GenericApiResponse> ReadLike(string someText);

        public abstract Task<GenericApiResponse> ReadLike(string someText, int id = 0);

        public abstract Task<GenericApiResponse> Update(object listOfUpdatedData);
    }
}