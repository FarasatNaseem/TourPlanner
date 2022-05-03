using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Model;

namespace TourPlanner.Client.BL.Authenticator
{
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
            if (!this.IsOK(tour))
            {
                return TourAuthenticationServiceMessage.Error;
            }

            return TourAuthenticationServiceMessage.Success;
        }

        private bool IsOK(Tour tour)
        {
            return !(string.IsNullOrEmpty(tour.Name) && string.IsNullOrEmpty(tour.From) && string.IsNullOrEmpty(tour.To) && string.IsNullOrEmpty(tour.TourDescription));
        }
    }
}
