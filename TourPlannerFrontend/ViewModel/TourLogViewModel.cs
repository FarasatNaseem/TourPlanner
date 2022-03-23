using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlannerFrontend.Model;
using TourPlannerFrontend.ViewModel.Commands;

namespace TourPlannerFrontend.ViewModel
{
    public class TourLogViewModel : BaseViewModel
    {
        private readonly ObservableCollection<TourViewModel> _tours = new ObservableCollection<TourViewModel>();

        public IEnumerable<TourViewModel> Tours => this._tours;

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
                Delete();
            });
        }


        private void Load()
        {
            this._tours.Add(new TourViewModel(new Tour("Tour 1", "TourDescription", "From", "To", "TransportType", "TotalDistance", new TimeSpan(), "RouteInformation")));
            this._tours.Add(new TourViewModel(new Tour("Tour 2", "TourDescription", "From", "To", "TransportType", "TotalDistance", new TimeSpan(), "RouteInformation")));
            this._tours.Add(new TourViewModel(new Tour("Tour 3", "TourDescription", "From", "To", "TransportType", "TotalDistance", new TimeSpan(), "RouteInformation")));
        }

        private void Add()
        {
            string name = "Tour " + (this._tours.Count + 1).ToString();
            this._tours.Add(new TourViewModel(new Tour(name, "TourDescription", "From", "To", "TransportType", "TotalDistance", new TimeSpan(), "RouteInformation")));
            OnPropertyChanged(nameof(name));
        }

        private void Delete()
        {
            this._tours.RemoveAt(this._tours.Count - 1);
        }
    }
}
