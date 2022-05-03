namespace TourPlanner.Client.BL.Wrapper
{
    using System;
    using TourPlanner.Client.BL.ViewModel;
    using TourPlanner.Model;

    public class TourLogWrapper : BaseViewModel
    {
        private int _id;
        private int _primaryKey;
        private double _distance;
        private DateTime _dateTime;
        private string _comment;
        private Difficulty _difficulty;
        private TimeSpan _duration;
        private Rating _rating;

        public TourLogWrapper(TourLog log)
        {
            this.ID = log.id;
            this.PrimaryKey = log.PrimaryKey;
            this.Distance = log.Distance;
            this.DateTime = log.DateTime;
            this.Comment = log.Comment;
            this.Difficulty = log.Difficulty;
            this.Duration = log.Duration;
            this.Rating = log.Rating;
        }

        public int ID
        {
            get => _id;
            set
            {
                if (_id == value) return;
                _id = value;
                OnPropertyChanged();
            }
        }

        public int PrimaryKey
        {
            get => _primaryKey;
            set
            {
                if (_primaryKey == value)
                {
                    return;
                }
                _primaryKey = value;
                OnPropertyChanged();
            }
        }

        public double Distance
        {
            get => _distance;
            set
            {
                if (_distance == value) return;
                _distance = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateTime
        {
            get => _dateTime;
            set
            {
                if (_dateTime == value) return;
                _dateTime = value;
                OnPropertyChanged();
            }
        }

        public string Comment
        {
            get => _comment;
            set
            {
                if (_comment == value) return;
                _comment = value;
                OnPropertyChanged();
            }
        }

        public Difficulty Difficulty
        {
            get => _difficulty;
            set
            {
                if (_difficulty == value) return;
                _difficulty = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan Duration
        {
            get => _duration;
            set
            {
                if (_duration == value)
                {
                    return;
                }

                _duration = value;

                OnPropertyChanged();
            }
        }

        public Rating Rating
        {
            get => _rating;
            set
            {
                if (_rating == value)
                {
                    return;
                }

                _rating = value;

                OnPropertyChanged();
            }
        }
    }
}
