using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlannerFrontend.Model;
using TourPlannerFrontend.ViewModel.Commands;

namespace TourPlannerFrontend.ViewModel
{
    public class TourListViewModel : BaseViewModel
    {
        private readonly ObservableCollection<TourViewModel> _tours = new ObservableCollection<TourViewModel>();

        public IEnumerable<TourViewModel> Tours => this._tours;

        public BaseCommand AddCommand { get; }
        public BaseCommand DeleteCommand { get; }

        public TourListViewModel()
        {
            AddCommand = new BaseCommand((_) =>
            {
                Add();
            });

            DeleteCommand = new BaseCommand((_) =>
            {
                Delete();
            });


            this.Load();
        }


        private void Load()
        {
            this._tours.Add(new TourViewModel(new Tour("Tour 1", "TourDescription", "Vienna", "Graz", "Bus", "x Km", new TimeSpan(2, 0, 0), "RouteInformation")));
            this._tours.Add(new TourViewModel(new Tour("Tour 2", "TourDescription", "Vienna", "Graz", "Bus", "x Km", new TimeSpan(2, 0, 0), "RouteInformation")));
            this._tours.Add(new TourViewModel(new Tour("Tour 3", "TourDescription", "Vienna", "Graz", "Bus", "x Km", new TimeSpan(2, 0, 0), "RouteInformation")));
        }

        private void Add()
        {
            string name = "Tour " + (this._tours.Count + 1).ToString();
            this._tours.Add(new TourViewModel(new Tour(name, "TourDescription", "Vienna", "Graz", "Bus", "x Km", new TimeSpan(2, 0, 0), "RouteInformation")));
            OnPropertyChanged(nameof(name));
        }

        private void Delete()
        {
            if (this._tours.Count != 0)
            {
                this._tours.RemoveAt(this._tours.Count - 1);
            }
        }
    }
}
