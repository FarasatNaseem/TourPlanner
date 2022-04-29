namespace TourPlanner.BL.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using TourPlanner.BL.Command;
    using TourPlanner.BL.Wrapper;
    using TourPlanner.Model;

    public class TourViewModel : BaseViewModel
    {
        private BaseCommand addCommand;
        private BaseCommand deleteCommand;
        private BaseCommand showLogCommand;
        private readonly BaseViewModel _tourLogsVM;
        private ITourPlannerCommand _showLogCommand;

        public TourViewModel(BaseViewModel tourLogsVM)
        {
            this.Tours = new ObservableCollection<TourWrapper>();
            this._tourLogsVM = tourLogsVM;
            this._showLogCommand = new ShowTourLogCommand(this._tourLogsVM, this.Tours);
            Load(); // fetch all data from database.
        }

        public ObservableCollection<TourWrapper> Tours { get; }

        // fetch all data from database.
        public void Load()
        {
            var logsOne = new List<TourLog>();
            logsOne.Add(new TourLog(1, 0, TransportType.Bike, 0.00, new DateTime(), "comment11", Difficulty.Easy, new TimeSpan(), Rating.Bad));
            logsOne.Add(new TourLog(2, 1, TransportType.Bike, 0.00, new DateTime(), "comment12", Difficulty.Easy, new TimeSpan(), Rating.Bad));
            this.Tours.Add(new TourWrapper(new Tour(0, "Tour1", "TD", "From", "To", 0.00, "Image", logsOne)));

            var logsTwo = new List<TourLog>();
            logsTwo.Add(new TourLog(1, 2, TransportType.Bike, 0.00, new DateTime(), "comment21", Difficulty.Easy, new TimeSpan(), Rating.Bad));
            logsTwo.Add(new TourLog(2, 3, TransportType.Bike, 0.00, new DateTime(), "comment22", Difficulty.Easy, new TimeSpan(), Rating.Bad));
            this.Tours.Add(new TourWrapper(new Tour(1, "Tour2", "TD", "From", "To", 0.00, "Image", logsTwo)));

            var logsThree = new List<TourLog>();
            logsThree.Add(new TourLog(1, 4, TransportType.Bike, 0.00, new DateTime(), "comment31", Difficulty.Easy, new TimeSpan(), Rating.Bad));
            logsThree.Add(new TourLog(2, 5, TransportType.Bike, 0.00, new DateTime(), "comment32", Difficulty.Easy, new TimeSpan(), Rating.Bad));
            this.Tours.Add(new TourWrapper(new Tour(2, "Tour3", "TD", "From", "To", 0.00, "Image", logsThree)));
        }


        public ICommand AddCommand => addCommand ??= new BaseCommand(Add);

        public ICommand DeleteCommand => deleteCommand ??= new BaseCommand(Delete);

        public ICommand ShowLogCommand => showLogCommand ??= new BaseCommand(this._showLogCommand.Execute);

        private void Add(object commandParameter)
        {
            throw new NotImplementedException();
        }

        private void Delete(object commandParameter)
        {
            throw new NotImplementedException();
        }
    }
}
