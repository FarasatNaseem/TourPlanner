namespace TourPlanner.Client.BL.Authenticator
{
    using TourPlanner.Model;
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
            if (!this.IsOK(tour) || !this.AreFromAndToDifferent(tour.From, tour.To))
            {
                return TourAuthenticationServiceMessage.Error;
            }

            return TourAuthenticationServiceMessage.Success;
        }

        private bool IsOK(Tour tour)
        {
            return !(string.IsNullOrEmpty(tour.Name) && string.IsNullOrEmpty(tour.From) && string.IsNullOrEmpty(tour.To) && string.IsNullOrEmpty(tour.TourDescription));
        }

        private bool AreFromAndToDifferent(string from, string to)
        {
            return from != to ? true : false;
        }
    }
}
