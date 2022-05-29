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
    public class UpdateTourViewModel : BaseViewModel
    {
        private int _id;
        private string _name;
        private string _description;
        private string _from;
        private string _to;
        private TransportType _transportType;

        private BaseCommand updateTourCommand;
        private ITourPlannerCommand _updateTourCommand;
        private readonly MainViewModel mainViewModel;

        private BaseCommand updateViewCommand;
        private ITourPlannerCommand _updateViewCommand;

        private ITourPlannerCommand _fetchSpecificTourCommand;

        public UpdateTourViewModel(MainViewModel mainViewModel, int id)
        {
            this.mainViewModel = mainViewModel;
            this.TourId = id;
            this._fetchSpecificTourCommand = new FetchSpecificTourCommand(this);
            this._fetchSpecificTourCommand.Execute(this.TourId);
          
            this.MessageViewModel = new MessageViewModel();
            this._updateTourCommand = new UpdateTourCommand(this);
            this._updateViewCommand = new UpdateViewCommand(mainViewModel);
        }

        public int TourId
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
            }
        }

        public MessageViewModel MessageViewModel { get; }

        public string Message
        {
            set => MessageViewModel.Message = value;
        }
        public ICommand UpdateCommand => updateTourCommand ??= new BaseCommand(this._updateTourCommand.Execute);
        public ICommand UpdateViewCommand => updateViewCommand ??= new BaseCommand(this._updateViewCommand.Execute);
    }
}
