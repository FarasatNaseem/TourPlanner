using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.Model.DbSchema
{
    public class TourSchemaWithLog : TourSchemaWithoutLog
    {
        public TourSchemaWithLog(int id, string name, string from, string to, string tourDescription, TransportType transportType, double distance, string routeImage, TimeSpan estimatedTime, List<TourLogSchema> logs) : base(id, name, from, to, tourDescription, transportType, distance, routeImage, estimatedTime)
        {
            this.Logs = logs;
        }

        public List<TourLogSchema> Logs { get; }
    }
}
