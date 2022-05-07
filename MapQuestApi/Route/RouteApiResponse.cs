namespace MapQuestApi.Route
{
    using System;
    public class RouteApiResponse
    {
        public RouteApiResponse(double direction, TimeSpan time)
        {
            this.Distance = direction;
            this.Time = time;
        }
        public double Distance
        {
            get;
        }
        public TimeSpan Time
        {
            get;
        }
    }
}
