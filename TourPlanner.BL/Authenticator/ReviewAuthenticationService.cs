using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Model;

namespace TourPlanner.Client.BL.Authenticator
{
    public enum ReviewAuthenticationServiceMessage
    {
        Success,
        Error,
        None
    }
    public class ReviewAuthenticationService : ITourPlannerAuthenticationService<ReviewAuthenticationServiceMessage, Review>
    {
        public ReviewAuthenticationServiceMessage Authenticate(Review dataToAuthenticate)
        {
            if(string.IsNullOrEmpty(dataToAuthenticate.Name) || string.IsNullOrEmpty(dataToAuthenticate.Feedback))
            {
                return ReviewAuthenticationServiceMessage.Error;
            }

            return ReviewAuthenticationServiceMessage.Success;

        }
    }
}
