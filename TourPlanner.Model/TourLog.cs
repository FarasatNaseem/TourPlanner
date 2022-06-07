namespace TourPlanner.Model
{
    using System;
    public class TourLog
    {
        public TourLog(int tourId, DateTime datetime, string comment, Difficulty difficulty, TimeSpan duration, Rating rating)
        {
            this.TourId = tourId;
            this.DateTime = datetime;
            this.Comment = comment;
            this.Difficulty = difficulty;
            this.TotalDuration = duration;
            this.Rating = rating;
        }

        public TourLog(int id, int tourId, DateTime datetime, string comment, Difficulty difficulty, TimeSpan duration, Rating rating) : this(tourId, datetime, comment, difficulty, duration, rating)
        {
            this.Id = id;
        }


        public int Id
        {
            get;
        }

        public int TourId { get; }

        public DateTime DateTime { get; }

        public string Comment { get; }

        public Difficulty Difficulty { get; }

        public TimeSpan TotalDuration { get; }

        public Rating Rating { get; }
    }
}