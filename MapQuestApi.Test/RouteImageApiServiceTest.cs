namespace MapQuestApi.Test
{
    using MapQuestApi.Image;
    using Nito.AsyncEx;
    using NUnit.Framework;

    public class RouteImageApiServiceTest : AbstractMapQuestTest
    {
        private AbstractMapQuestApiService<RouteImageApiResponse> _abstractMapQuestApiService;

        [Test]
        public override void GetResponseMustBeTrue_Test()
        {
            this._abstractMapQuestApiService = new RouteImageApiService(new RouteImageApiRequest("600", "400", "Vienna", "Graz"));

            var response = AsyncContext.Run(() => this._abstractMapQuestApiService.Get());

            Assert.IsTrue(response.IsFetched);
        }
    }
}