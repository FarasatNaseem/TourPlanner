namespace MapQuestApi.Route
{
    using System;
    public class RouteApiResponse
    {
        public RouteApiResponse(double direction, TimeSpan time, bool isFetched)
        {
            this.Distance = direction;
            this.Time = time;
            this.IsFetched = isFetched;
        }
        public double Distance
        {
            get;
        }
        public TimeSpan Time
        {
            get;
        }

        public bool IsFetched
        {
            get;
        }
    }
}
