using MapQuestApi.Route;
using Nito.AsyncEx;
using NUnit.Framework;

namespace MapQuestApi.Test
{
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

        //[SetUp]
        //public void Setup()
        //{
        //}

        //[Test]
        //public void GetResponseMustBeTrue_Test()
        //{
        //    this._abstractMapQuestApiService = new RouteApiService(new RouteApiRequest("Vienna", "Graz"));

        //    var response = AsyncContext.Run(() => this._abstractMapQuestApiService.Get());

        //    Assert.IsTrue(response.IsFetched);
        //}
    }
}