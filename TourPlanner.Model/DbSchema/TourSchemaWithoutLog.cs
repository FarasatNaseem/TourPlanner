using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.Model.DbSchema
{
    public class TourSchemaWithoutLog
    {
        public TourSchemaWithoutLog(int id, string name, string from, string to, string tourDescription, TransportType transportType, double distance, string routeImage, TimeSpan estimatedTime)
        {
            this.Id = id;
            this.Name = name;
            this.From = from;
            this.To = to;
            this.TourDescription = tourDescription;
            this.TransportType = transportType;
            this.Distance = distance;
            this.RouteImage = routeImage;
            this.EstimatedTime = estimatedTime;
        }

        public int Id { get; }

        public string Name { get; }

        public string TourDescription { get; }

        public string From { get; }

        public string To { get; }

        public double Distance { get; }

        public TransportType TransportType { get; }

        public string RouteImage { get; }

        public TimeSpan EstimatedTime { get; }
    }
}
