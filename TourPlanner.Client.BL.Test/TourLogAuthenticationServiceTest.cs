using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.Authenticator;
using TourPlanner.Model;

namespace TourPlanner.Client.BL.Test
{
    public class TourLogAuthenticationServiceTest
    {
        private ITourPlannerAuthenticationService<TourLogAuthenticationServiceMessage, TourLog> _tourLogAuthenticationService;

        [SetUp]
        public void Setup()
        {
            this._tourLogAuthenticationService = new TourLogAuthenticationService();
        }

        [Test]
        public void AuthenticateMustReturnError_Test()
        {
            var tourLog = new TourLog(1, new DateTime(), "comment", Difficulty.Easy, new TimeSpan(), Rating.None);

            var result = this._tourLogAuthenticationService.Authenticate(tourLog);

            Assert.AreEqual(result, TourLogAuthenticationServiceMessage.Error);
        }
    }
}