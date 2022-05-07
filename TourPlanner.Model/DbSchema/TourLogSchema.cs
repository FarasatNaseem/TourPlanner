using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.Model.DbSchema
{
    public class TourLogSchema
    {
        public TourLogSchema(int id, int tourId, DateTime datetime, string comment, Difficulty difficulty, TimeSpan duration, Rating rating)
        {
            this.Id = id;
            this.TourId = tourId;
            this.DateTime = datetime;
            this.Comment = comment;
            this.Difficulty = difficulty;
            this.TotalDuration = duration;
            this.Rating = rating;
        }

        public int Id
        {
            get;
        }

        public int TourId { get; }

        public DateTime DateTime { get; }

        public string Comment { get; }

        public Difficulty Difficulty { get; }

        public TimeSpan TotalDuration { get; set; }

        public Rating Rating { get; }
    }
}
