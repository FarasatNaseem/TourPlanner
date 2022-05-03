using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlanner.Client.BL.Authenticator;
using TourPlanner.Client.BL.Command;
using TourPlanner.Model;

namespace TourPlanner.Client.BL.ViewModel
{
    public class AddTourViewModel : BaseViewModel
    {
        private string _name;
        private string _description;
        private string _from;
        private string _to;
        private TransportType _transportType;

        private BaseCommand _addCommand;
        private ITourPlannerCommand _addTourCommand;
        public AddTourViewModel()
        {
            this.MessageViewModel = new MessageViewModel();
            this._addTourCommand = new AddTourCommand(this);
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name == value)
                {
                    return;
                }

                _name = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(CanAddTour));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (_description == value)
                {
                    return;
                }

                _description = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(CanAddTour));
            }
        }

        public string From
        {
            get => _from;
            set
            {
                if (_from == value)
                {
                    return;
                }

                _from = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(CanAddTour));
            }
        }

        public string To
        {
            get => _to;
            set
            {
                if (_to == value)
                {
                    return;
                }

                _to = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(CanAddTour));
            }
        }

        public TransportType TransportType
        {
            get => _transportType;
            set
            {
                if (_transportType == value)
                {
                    return;
                }

                _transportType = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(CanAddTour));
            }
        }

        public MessageViewModel MessageViewModel { get; }

        public string Message
        {
            set => MessageViewModel.Message = value;
        }

        public bool CanAddTour => !string.IsNullOrEmpty(Name) &&
           !string.IsNullOrEmpty(From) &&
           !string.IsNullOrEmpty(To) &&
           !string.IsNullOrEmpty(Description);

        public ICommand AddCommand => _addCommand ??= new BaseCommand(this._addTourCommand.Execute);
    }
}