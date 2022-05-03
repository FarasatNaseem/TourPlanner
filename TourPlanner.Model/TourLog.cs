﻿namespace TourPlanner.Model
{
    using System;
    public class TourLog
    {
        public TourLog(int id, int primaryKey, TransportType type, double distance, DateTime dateTime, string comment, Difficulty difficulty, TimeSpan duration, Rating rating)
        {
            this.id = id;
            this.PrimaryKey = primaryKey;
            this.Distance = distance;
            this.DateTime = dateTime;
            this.Comment = comment;
            this.Difficulty = difficulty;
            this.Duration = duration;
            this.Rating = rating;
        }

        public int id { get; }

        public int PrimaryKey { get; }

        public double Distance { get; }

        public DateTime DateTime { get; }

        public string Comment { get; }

        public Difficulty Difficulty { get; }

        public TimeSpan Duration { get; }

        public Rating Rating { get; }
    }
}