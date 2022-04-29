namespace TourPlanner.BL.Wrapper
{
    using System.Linq;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using TourPlanner.BL.ViewModel;
    using TourPlanner.Model;
    public class TourWrapper : BaseViewModel
    {
        private int _id;
        private string _name;
        private string _description;
        private string _from;
        private string _to;
        private double _distance;
        private string _routeImage;
        private ObservableCollection<TourLogWrapper> logs;

        public TourWrapper(Tour tour)
        {
            this.ID = tour.Id;
            this.Name = tour.Name;
            this.From = tour.From;
            this.To = tour.To;
            this.Distance = tour.Distance;
            this.Description = tour.TourDescription;
            this.RouteImage = tour.RouteImage;
            this.logs = new ObservableCollection<TourLogWrapper>(tour.Logs.Select(WrapTourLog).ToList());
        }


        public int ID
        {
            get => _id;
            set
            {
                if (_id == value) return;
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

        public double Distance
        {
            get => _distance;
            set
            {
                if (_distance == value)
                {
                    return;
                }

                _distance = value;

                OnPropertyChanged();
            }
        }


        public string RouteImage
        {
            get => _routeImage;

            set
            {
                if (_routeImage == value)
                {
                    return;
                }

                _routeImage = value;

                OnPropertyChanged();
            }
        }

        public ObservableCollection<TourLogWrapper> Logs
        {
            get => logs;
            set
            {
                if (logs == value)
                {
                    return;
                }

                logs = value;

                OnPropertyChanged();
            }
        }

        private TourLogWrapper WrapTourLog(TourLog log)
        {
            var wrapper = new TourLogWrapper(log);
            wrapper.PropertyChanged += OnValidationChanged;
            return wrapper;
        }

        private void OnValidationChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "IsValid") return;
            OnPropertyChanged("Logs");
        }
    }
}
