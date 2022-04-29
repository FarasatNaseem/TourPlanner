using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TourPlanner.BL.Command;
using TourPlanner.BL.Wrapper;
using TourPlanner.Model;

namespace TourPlanner.BL.ViewModel
{
    public class TourLogViewModel : BaseViewModel
    {
        //public ObservableCollection<TourWrapper> _tours = new ObservableCollection<TourWrapper>();
        //public IEnumerable<TourWrapper> Tours => this._tours;
        public BaseCommand AddCommand { get; }
        //public BaseCommand DeleteCommand { get; }

        //public TourLogViewModel()
        //{
        //    AddCommand = new BaseCommand((_) =>
        //    {
        //        Add();
        //    });

        //    DeleteCommand = new BaseCommand((_) =>
        //    {
        //        Delete(_);
        //    });

        //}


        private BaseCommand deleteCommand;
        private ITourPlannerCommand _deleteLogCommand;

        public ObservableCollection<TourWrapper> Tours { get; }

        public TourLogViewModel()
        {
            this.Tours = new ObservableCollection<TourWrapper>();
            this._deleteLogCommand = new DeleteTourLogCommand(this.Tours);
        }

        public ICommand DeleteCommand => deleteCommand ??= new BaseCommand(this._deleteLogCommand.Execute);

        //private void Add()
        //{
        //    string name = "Tour " + (this._tours.Count + 1).ToString();
        //    //this._tours.Add(new TourViewModel(new Tour(name, "TourDescription", "From", "To", "TransportType", "TotalDistance", new TimeSpan(), "RouteInformation")));
        //}



        //private void Delete(object data)
        //{
        //    int primaryKey = (int)data;

        //    for (int tourIndex = 0; tourIndex < this._tours.Count; tourIndex++)
        //    {
        //        for (int logIndex = 0; logIndex < this._tours[tourIndex].Logs.Count; logIndex++)
        //        {
        //            if (this._tours[tourIndex].Logs[logIndex].PrimaryKey == primaryKey)
        //            {
        //                this._tours[tourIndex].Logs.RemoveAt(logIndex);
        //            }
        //        }
        //    }


        //    //this._tours.Clear();
        //    //var rand = new Random();
        //    //int randId = rand.Next(0, 3);
        //    //    this._tours.Add(this.testTours[randId]);
        //    //this._tours.RemoveAt(this._tours.Count - 1);
        //}
    }
}