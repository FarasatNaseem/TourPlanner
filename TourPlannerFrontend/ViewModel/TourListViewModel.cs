using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TourPlannerFrontend.Model;
using TourPlannerFrontend.ViewModel.Commands;
using TourPlannerFrontend.ViewModel.Wrapper;

namespace TourPlannerFrontend.ViewModel
{
    public class TourListViewModel : BaseViewModel
    {
        //private readonly ObservableCollection<TourViewModel> _tours = new ObservableCollection<TourViewModel>();

        //public IEnumerable<TourViewModel> Tours => this._tours;



        //public BaseCommand AddCommand { get; }
        //public BaseCommand DeleteCommand { get; }

        //public BaseCommand ShowLogsCommand { get; }
        //public BaseViewModel TourLogsVM { get; }

        //public TourListViewModel(BaseViewModel tourLogsVM)
        //{
        //    TourLogsVM = tourLogsVM;

        //    AddCommand = new BaseCommand((_) =>
        //    {
        //        Add();
        //    });

        //    DeleteCommand = new BaseCommand((data) =>
        //    {
        //        Delete((TourViewModel)data);
        //    });

        //    ShowLogsCommand = new BaseCommand((data) =>
        //    {
        //        ShowLogs((TourViewModel)data);
        //    });


        //  //  this.Load();
        //}


        //private void Load()
        //{
        //    //this._tours.Add(new TourViewModel(new Tour("Tour 1", "TourDescription", "Vienna", "Graz", "Bus", "x Km", new TimeSpan(2, 0, 0), "RouteInformation")));
        //    //this._tours.Add(new TourViewModel(new Tour("Tour 2", "TourDescription", "Vienna", "Graz", "Bus", "x Km", new TimeSpan(2, 0, 0), "RouteInformation")));
        //    //this._tours.Add(new TourViewModel(new Tour("Tour 3", "TourDescription", "Vienna", "Graz", "Bus", "x Km", new TimeSpan(2, 0, 0), "RouteInformation")));
        //}

        //private void Add()
        //{
        //    string name = "Tour " + (this._tours.Count + 1).ToString();
        //    //this._tours.Add(new TourViewModel(new Tour(name, "TourDescription", "Vienna", "Graz", "Bus", "x Km", new TimeSpan(2, 0, 0), "RouteInformation")));
        //}


        //private void Delete(TourViewModel data)
        //{
        //    //var rand = new Random();
        //    //int randId = rand.Next(0, 3);
        //    //var tourLog = this.testTours.Where(x => x.Name.Contains(randId.ToString()));
        //    //this._tours.Add((TourViewModel)tourLog);
        //    if (this._tours.Count != 0)
        //    {
        //        this._tours.RemoveAt(this._tours.Count - 1);
        //    }
        //}

        //private void ShowLogs(TourViewModel data)
        //{
        //    return;
        //}

        private BaseCommand addCommand;
        private BaseCommand deleteCommand;
        private BaseCommand showLogCommand;
        private readonly BaseViewModel _tourLogsVM;
        public TourListViewModel(BaseViewModel tourLogsVM)
        {
            this.Tours = new ObservableCollection<TourWrapper>();
            this._tourLogsVM = tourLogsVM;

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
            this.Tours.Add(new TourWrapper(new Tour(2, "Tour2", "TD", "From", "To", 0.00, "Image", logsThree)));
        }


        public ICommand AddCommand => addCommand ??= new BaseCommand(Add);
        public ICommand DeleteCommand => deleteCommand ??= new BaseCommand(Delete);

        public ICommand ShowLogCommand => showLogCommand ??= new BaseCommand(ShowLog);
        private void Add(object commandParameter)
        {
            throw new NotImplementedException();
        }

        private void ShowLog(object id)
        {
            int logId = (int)id;
            var tourLogViewModel = (TourLogViewModel)this._tourLogsVM;
            tourLogViewModel._tours.Clear();
            tourLogViewModel._tours.Add(this.Tours[logId]);
        }


        private void Delete(object commandParameter)
        {
            throw new NotImplementedException();
        }
    }
}
