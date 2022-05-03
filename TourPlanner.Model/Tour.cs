namespace TourPlanner.Model
{
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

        public Tour(int id, string name, string tourDescription, string from, string to, double distance, TransportType transportType, string routeImage, List<TourLog> logs) : this(name, from, to, tourDescription, transportType)
        {
            this.Id = id;
            this.Distance = distance;
            this.RouteImage = routeImage;
            this.Logs = logs;
        }

        public int Id { get; }

        public string Name { get; }

        public string TourDescription { get; }

        public string From { get; }

        public string To { get; }

        public double Distance { get; }

        public TransportType TransportType { get; }
        public string RouteImage { get; }

        public List<TourLog> Logs { get; }
    }
}