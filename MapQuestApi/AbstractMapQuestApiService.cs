namespace MapQuestApi
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public abstract class AbstractMapQuestApiService<T> where T : class
    {
        public AbstractMapQuestApiService()
        {
            this.HttpClient = new HttpClient();
        }
        protected HttpClient HttpClient
        {
            get;
            private set;
        }

        public abstract Task<T> Get();
    }
}