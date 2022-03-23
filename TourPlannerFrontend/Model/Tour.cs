namespace TourPlannerFrontend.Model
{
    using System;

    public class Tour
    {
        public Tour( string name, string tourDescription, string from, string to, string transportType, string tourDistance, TimeSpan estimatedTime, string routeInformation)
        {
            this.Name = name;
            this.TourDescription = tourDescription;
            this.From = from;
            this.To = to;
            this.TransportType = transportType;
            this.TourDistance = tourDistance;
            this.EstimatedTime = estimatedTime;
            this.RouteInformation = routeInformation;
        }

        public string Name { get; }
        public string TourDescription { get; }
        public string From { get; }
        public string To { get; }
        public string TransportType { get; }
        public string TourDistance { get; }
        public TimeSpan EstimatedTime { get; }
        public string RouteInformation { get; } // An image with tour map
    }
}
