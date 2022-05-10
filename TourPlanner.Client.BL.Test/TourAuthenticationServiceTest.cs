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
    public class TourAuthenticationServiceTest
    {
        private ITourPlannerAuthenticationService<TourAuthenticationServiceMessage, Tour> _tourAuthenticationService;

        [SetUp]
        public void Setup()
        {
            this._tourAuthenticationService = new TourAuthenticationService();
        }

        [Test]
        public void AuthenticateMustReturnSuccess_Test()
        {
            var tour = new Tour("TourName", "Vienna", "Graz", "TourDes", TransportType.Bike);

            var result = this._tourAuthenticationService.Authenticate(tour);

            Assert.AreEqual(result, TourAuthenticationServiceMessage.Success);
        }
    }
}
