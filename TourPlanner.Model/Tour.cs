namespace TourPlanner.Model
{
    using System.Collections.Generic;
    public class Tour
    {
        public Tour(int id, string name, string tourDescription, string from, string to, double distance, string routeImage, List<TourLog> logs)
        {
            this.Id = id;
            this.Name = name;
            this.TourDescription = tourDescription;
            this.From = from;
            this.To = to;
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

        public string RouteImage { get; }

        public List<TourLog> Logs { get; }
    }
}