namespace TourPlannerFrontend.ViewModel
{
    using System;
    using TourPlannerFrontend.Model;

    public class TourViewModel : BaseViewModel
    {
        private string _name;
        private string _tourDescription;
        private string _from;
        private string _to;
        private string _transportType;
        private string _tourDistance;
        private TimeSpan _estimatedTime;
        private string _routeInformation;

        public TourViewModel(Tour tour)
        {
            this.Name = tour.Name;
            this.TourDescription = tour.TourDescription;
            this.From = tour.From;
            this.To = tour.To;
            this.TourDistance = tour.TourDistance;
            this.EstimatedTime = tour.EstimatedTime;
            this.TransportType = tour.TransportType;
            this.RouteInformation = tour.RouteInformation;
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }

        }

        public string TourDescription
        {
            get
            {
                return _tourDescription;
            }
            set
            {
                this._tourDescription = value;
                this.OnPropertyChanged(nameof(TourDescription));

            }
        }
        public string From
        {
            get
            {
                return this._from;
            }
            set
            {
                this._from = value;
                this.OnPropertyChanged(nameof(From));

            }
        }
        public string To
        {
            get
            {
                return this._to;
            }
            set
            {
                this._to = value;
                this.OnPropertyChanged(nameof(To));

            }
        }
        public string TransportType
        {
            get
            {
                return this._transportType;
            }
            set
            {
                this._transportType = value;
                this.OnPropertyChanged(nameof(TransportType));

            }
        }
        public string TourDistance
        {
            get
            {
                return this._tourDistance;
            }
            set
            {
                this._tourDistance = value;
                this.OnPropertyChanged(nameof(TourDistance));

            }
        }
        public TimeSpan EstimatedTime
        {
            get
            {
                return this._estimatedTime;
            }
            set
            {
                this._estimatedTime = value;
                this.OnPropertyChanged(nameof(EstimatedTime));

            }
        }
        public string RouteInformation
        {
            get
            {
                return this._routeInformation;
            }
            set
            {
                this._routeInformation = value;
                this.OnPropertyChanged(nameof(RouteInformation));

            }
        } // An image with tour map
    }
}
