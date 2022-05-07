using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TourPlanner.Client.BL.Command;
using TourPlanner.Client.BL.Wrapper;
using TourPlanner.Model;

namespace TourPlanner.Client.BL.ViewModel
{
    public class TourLogViewModel : BaseViewModel
    {
        //public ObservableCollection<TourWrapper> _tours = new ObservableCollection<TourWrapper>();
        //public IEnumerable<TourWrapper> Tours => this._tours;

        //public TourLogViewModel()
        //{
        
        //}


        private BaseCommand deleteCommand;
        private BaseCommand navigateToTourLogFormCommand;

        private ITourPlannerCommand _deleteLogCommand;
        private ITourPlannerCommand _navigateToTourLogFormCommand;

        public ObservableCollection<TourWrapper> Tours { get; }

        public TourLogViewModel()
        {
            this.Tours = new ObservableCollection<TourWrapper>();
            this._deleteLogCommand = new DeleteTourLogCommand(this.Tours);
            this._navigateToTourLogFormCommand = new NagivateToTourLogFormCommand();
        }

        public ICommand DeleteCommand => deleteCommand ??= new BaseCommand(this._deleteLogCommand.Execute);
        public ICommand NavigateCommand => navigateToTourLogFormCommand ??= new BaseCommand(this._navigateToTourLogFormCommand.Execute);
    }
}