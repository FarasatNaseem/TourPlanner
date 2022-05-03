using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Model;

namespace TourPlanner.Client.BL.Authenticator
{
    public enum TourLogAuthenticationServiceMessage
    {
        Success,
        None
    }
    public class TourLogAuthenticationService : ITourPlannerAuthenticationService<TourLogAuthenticationServiceMessage, TourLog>
    {
        public TourLogAuthenticationServiceMessage Authenticate(TourLog dataToAuthenticate)
        {
            throw new NotImplementedException();
        }
    }
}
