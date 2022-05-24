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
    public class UpdateTourLogViewModel : BaseViewModel
    {
        public UpdateTourLogViewModel(MainViewModel mainViewModel, int tourLogId, int tourId)
        {
            this.mainViewModel = mainViewModel;
            this.TourLogId = tourLogId;
            this.TourId = tourId;
            this.mainViewModel = mainViewModel;
            this.MessageViewModel = new MessageViewModel();
            this._updateTourLogCommand = new UpdateTourLogCommand(this);
            this._updateViewCommand = new UpdateViewCommand(mainViewModel);
        }

        private int _id;
        private DateTime _dateTime;
        private string _comment = null;
        private Difficulty _difficulty = Difficulty.None;
        private TimeSpan _duration;
        private Rating _rating = Rating.None;


        private BaseCommand _updateCommand;
        private readonly ITourPlannerCommand _updateTourLogCommand;
        private readonly MainViewModel mainViewModel;
        private BaseCommand updateViewCommand;
        private ITourPlannerCommand _updateViewCommand;


        public int TourLogId
        {
            get;
            private set;
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

        public MessageViewModel MessageViewModel { get; }

        public string Message
        {
            set => MessageViewModel.Message = value;
        }


        public ICommand UpdateCommand => _updateCommand ??= new BaseCommand(this._updateTourLogCommand.Execute);
        public ICommand UpdateViewCommand => updateViewCommand ??= new BaseCommand(this._updateViewCommand.Execute);
    }
}
