namespace MapQuestApi.Test
{
    using NUnit.Framework;
    using MapQuestApi.Route;
    using Nito.AsyncEx;

    public class RouteApiServiceTest : AbstractMapQuestTest
    {
        private AbstractMapQuestApiService<RouteApiResponse> _abstractMapQuestApiService;
       

        [Test]
        public override void GetResponseMustBeTrue_Test()
        {
            this._abstractMapQuestApiService = new RouteApiService(new RouteApiRequest("Vienna", "Graz"));

            var response = AsyncContext.Run(() => this._abstractMapQuestApiService.Get());

            Assert.IsTrue(response.IsFetched);
        }
    }
}