namespace TourPlanner.Client.BL.Authenticator
{
    using System;
    using TourPlanner.Model;

    public enum TourLogAuthenticationServiceMessage
    {
        Success,
        Error,
        None
    }
    public class TourLogAuthenticationService : ITourPlannerAuthenticationService<TourLogAuthenticationServiceMessage, TourLog>
    {
        public TourLogAuthenticationServiceMessage Authenticate(TourLog tourLog)
        {
            if (!this.IsOK(tourLog))
            {
                return TourLogAuthenticationServiceMessage.Error;
            }

            return TourLogAuthenticationServiceMessage.Success;
        }

        private bool IsOK(TourLog tourLog)
        {
            return !(string.IsNullOrEmpty(tourLog.Comment) ||
          (tourLog.Rating == Rating.None) || (tourLog.Difficulty == Difficulty.None) ||
           (tourLog.DateTime == default(DateTime)) ||
           (tourLog.TotalDuration == default(TimeSpan)));
        }
    }
}
