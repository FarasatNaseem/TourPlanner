using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlanner.Client.BL.Command;
using TourPlanner.Model;

namespace TourPlanner.Client.BL.ViewModel
{
    public class AddTourLogViewModel : BaseViewModel
    {
        private int _id;
        private DateTime _dateTime;
        private string _comment = null;
        private Difficulty _difficulty = Difficulty.None;
        private TimeSpan _duration;
        private Rating _rating = Rating.None;

        private BaseCommand _addCommand;
        private readonly ITourPlannerCommand _addTourLogCommand;

        public AddTourLogViewModel()
        {
            this.MessageViewModel = new MessageViewModel();
            this._addTourLogCommand = new AddTourLogCommand(this);
        }

        public int TourId
        {
            get => _id;
            set
            {

                if (_id == value)
                    return;
                _id = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateTime
        {
            get => _dateTime;
            set
            {
                if (_dateTime == value)
                    return;
                _dateTime = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanAddTourLog));
            }
        }

        public string Comment
        {
            get => _comment;
            set
            {
                if (_comment == value)
                    return;
                _comment = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanAddTourLog));
            }
        }

        public Difficulty Difficulty
        {
            get => _difficulty;
            set
            {
                if (_difficulty == value)
                    return;
                _difficulty = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanAddTourLog));
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
                OnPropertyChanged(nameof(CanAddTourLog));
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
                OnPropertyChanged(nameof(CanAddTourLog));
            }
        }

        public MessageViewModel MessageViewModel { get; }

        public string Message
        {
            set => MessageViewModel.Message = value;
        }

        public bool CanAddTourLog => !string.IsNullOrEmpty(Comment) &&
          (Rating != Rating.None) && (Difficulty != Difficulty.None) &&
           (this.DateTime != default(DateTime)) &&
           (this.TotalDuration != default(TimeSpan));

        public ICommand AddCommand => _addCommand ??= new BaseCommand(this._addTourLogCommand.Execute);
    }
}
