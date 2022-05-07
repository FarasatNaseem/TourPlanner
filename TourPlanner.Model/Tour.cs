namespace TourPlanner.Model
{
    using System;
    using System.Collections.Generic;
    public class Tour
    {
        public Tour (string name,string from, string to, string tourDescription, TransportType transportType)
        {
            this.Name = name;
            this.From = from;
            this.To = to;
            this.TourDescription = tourDescription;
            this.TransportType = transportType;
        }

        public Tour(int id, string name, string from, string to, string tourDescription, TransportType transportType, double distance, string routeImage, TimeSpan estimatedTime, List<TourLog> logs) : this(name, from, to, tourDescription, transportType)
        {
            this.Id = id;
            this.Distance = distance;
            this.RouteImage = routeImage;
            this.EstimatedTime = estimatedTime;
            this.Logs = logs;
        }


        public int Id { get; }

        public string Name { get; }

        public string TourDescription { get; }

        public string From { get; }

        public string To { get; }

        public double Distance { get; set; }

        public TransportType TransportType { get; }

        public string RouteImage { get; set; }

        public TimeSpan EstimatedTime { get; set; }

        public List<TourLog> Logs { get; set; }
    }
}