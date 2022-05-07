namespace TourPlanner.Client.BL.Wrapper
{
    using System;
    using TourPlanner.Client.BL.ViewModel;
    using TourPlanner.Model;

    public class TourLogWrapper : BaseViewModel
    {
        private int _tourId;
        private int _id;
        private DateTime _dateTime;
        private string _comment;
        private Difficulty _difficulty;
        private TimeSpan _duration;
        private Rating _rating;

        public TourLogWrapper(TourLog log)
        {
            this.TourID = log.TourId;
            this.Id = log.Id;
            this.DateTime = log.DateTime;
            this.Comment = log.Comment;
            this.Difficulty = log.Difficulty;
            this.TotalDuration = log.TotalDuration;
            this.Rating = log.Rating;
        }

        public int TourID
        {
            get => _tourId;
            set
            {
                if (_tourId == value) return;
                _tourId = value;
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get => _id;
            set
            {
                if (_id == value)
                {
                    return;
                }
                _id = value;
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

        public TimeSpan TotalDuration
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
