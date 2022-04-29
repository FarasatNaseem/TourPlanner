using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlannerFrontend.Model;
using TourPlannerFrontend.ViewModel.Commands;
using TourPlannerFrontend.ViewModel.Wrapper;

namespace TourPlannerFrontend.ViewModel
{
    public class TourLogViewModel : BaseViewModel
    {
        public ObservableCollection<TourWrapper> _tours = new ObservableCollection<TourWrapper>();
        public IEnumerable<TourWrapper> Tours => this._tours;
        public BaseCommand AddCommand { get; }
        public BaseCommand DeleteCommand { get; }

        public TourLogViewModel()
        {
            AddCommand = new BaseCommand((_) =>
            {
                Add();
            });

            DeleteCommand = new BaseCommand((_) =>
            {
                Delete(_);
            });

            //  this.Load();
        }

        public void Load()
        {
            //var logsOne = new List<TourLog>();
            //logsOne.Add(new TourLog(1, TransportType.Bike, 0.00, new DateTime(), "comment11", Difficulty.Easy, new TimeSpan(), Rating.Bad));
            //logsOne.Add(new TourLog(2, TransportType.Bike, 0.00, new DateTime(), "comment12", Difficulty.Easy, new TimeSpan(), Rating.Bad));
            //this._tours.Add(new TourWrapper(new Tour(1, "T1", "TD", "From", "To", 0.00, "Image", logsOne)));
        }


        private void Add()
        {
            string name = "Tour " + (this._tours.Count + 1).ToString();
            //this._tours.Add(new TourViewModel(new Tour(name, "TourDescription", "From", "To", "TransportType", "TotalDistance", new TimeSpan(), "RouteInformation")));
        }

        private void Delete(object data)
        {
            int primaryKey = (int)data;

            for (int tourIndex = 0; tourIndex < this._tours.Count; tourIndex++)
            {
                for (int logIndex = 0; logIndex < this._tours[tourIndex].Logs.Count; logIndex++)
                {
                    if(this._tours[tourIndex].Logs[logIndex].PrimaryKey == primaryKey)
                    {
                        this._tours[tourIndex].Logs.RemoveAt(logIndex);
                    }
                }
            }


            //this._tours.Clear();
            //var rand = new Random();
            //int randId = rand.Next(0, 3);
            //    this._tours.Add(this.testTours[randId]);
            //this._tours.RemoveAt(this._tours.Count - 1);
        }
    }
}
