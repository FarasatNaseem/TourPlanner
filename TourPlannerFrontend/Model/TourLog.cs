using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlannerFrontend.Model
{
    public class TourLog
    {
        public TourLog(int id, int primaryKey, TransportType type, double distance, DateTime dateTime, string comment, Difficulty difficulty, TimeSpan duration, Rating rating)
        {
            this.id = id;
            this.PrimaryKey = primaryKey;
            this.Type = type;
            this.Distance = distance;
            this.DateTime = dateTime;
            this.Comment = comment;
            this.Difficulty = difficulty;
            this.Duration = duration;
            this.Rating = rating;
        }

        public int id { get; }

        public int PrimaryKey { get; }

        public TransportType Type { get; }

        public double Distance { get; }

        public DateTime DateTime { get; }

        public string Comment { get; }

        public Difficulty Difficulty { get; }

        public TimeSpan Duration { get; }

        public Rating Rating { get; }
    }
}
