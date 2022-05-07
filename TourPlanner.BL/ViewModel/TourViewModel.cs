namespace TourPlanner.Client.BL.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using TourPlanner.Client.BL.Command;
    using TourPlanner.Client.BL.Wrapper;
    using TourPlanner.Model;

    public class TourViewModel : BaseViewModel
    {
        private BaseCommand deleteCommand;
        private BaseCommand showLogCommand;
        private BaseCommand loadCommand;
        private BaseCommand navigateToTourFormCommand;

        private readonly BaseViewModel _tourLogsVM;
        private ITourPlannerCommand _showLogCommand;
        private ITourPlannerCommand _loadTourCommand;
        private ITourPlannerCommand _navigateToTourFormCommand;

        public TourViewModel(BaseViewModel tourLogsVM)
        {
            this.Tours = new ObservableCollection<TourWrapper>();
            this._tourLogsVM = tourLogsVM;
            this._showLogCommand = new ShowTourLogCommand(this._tourLogsVM, this.Tours);
            this._loadTourCommand = new LoadTourCommand(this);
            this._navigateToTourFormCommand = new NavigateToTourFormCommand();
          //  Load(); // fetch all data from database.
        }

        public ObservableCollection<TourWrapper> Tours { get; }

        // fetch all data from database.
        public void Load()
        {
            //var logsOne = new List<TourLog>();
            //logsOne.Add(new TourLog(1, 0, new DateTime(), "comment11", Difficulty.Easy, new TimeSpan(), Rating.Bad));
            //logsOne.Add(new TourLog(2, 1, new DateTime(), "comment12", Difficulty.Easy, new TimeSpan(), Rating.Bad));
            //this.Tours.Add(new TourWrapper(new Tour(0, "Tour1", "TD", "From", "To", 0.00, TransportType.Bike, "Image", new TimeSpan(), logsOne)));

            //var logsTwo = new List<TourLog>();
            //logsTwo.Add(new TourLog(1, 2, new DateTime(), "comment21", Difficulty.Easy, new TimeSpan(), Rating.Bad));
            //logsTwo.Add(new TourLog(2, 3, new DateTime(), "comment22", Difficulty.Easy, new TimeSpan(), Rating.Bad));
            //this.Tours.Add(new TourWrapper(new Tour(1, "Tour2", "TD", "From", "To", 0.00, TransportType.Bike, "Image", new TimeSpan(), logsTwo)));

            //var logsThree = new List<TourLog>();
            //logsThree.Add(new TourLog(1, 4, new DateTime(), "comment31", Difficulty.Easy, new TimeSpan(), Rating.Bad));
            //logsThree.Add(new TourLog(2, 5, new DateTime(), "comment32", Difficulty.Easy, new TimeSpan(), Rating.Bad));
            //this.Tours.Add(new TourWrapper(new Tour(2, "Tour3", "TD", "From", "To", 0.00, TransportType.Bike, "Image", new TimeSpan(), logsThree)));
        }

        public ICommand DeleteCommand => deleteCommand ??= new BaseCommand(Delete);

        public ICommand ShowLogCommand => showLogCommand ??= new BaseCommand(this._showLogCommand.Execute);

        public ICommand LoadCommand => loadCommand ??= new BaseCommand(this._loadTourCommand.Execute);

        public ICommand NavigateCommand => navigateToTourFormCommand ??= new BaseCommand(this._navigateToTourFormCommand.Execute);

        private void Delete(object commandParameter)
        {
            throw new NotImplementedException();
        }
    }
}
