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

        private BaseCommand deleteCommand;
        private BaseCommand navigateToTourLogFormCommand;
        private BaseCommand generateNormalReportCommand;

        private ITourPlannerCommand _deleteLogCommand;
        private ITourPlannerCommand _navigateToTourLogFormCommand;
        private ITourPlannerCommand _generateNormalReportCommand;

        public ObservableCollection<TourWrapper> Tours { get; set; }
        public BaseViewModel SearchVM { get; set; }

        public TourLogViewModel()
        {
            this.Tours = new ObservableCollection<TourWrapper>();
            this._deleteLogCommand = new DeleteTourLogCommand(this.Tours);
            this._navigateToTourLogFormCommand = new NagivateToTourLogFormCommand();
            this._generateNormalReportCommand = new GenerateNormalReportCommand();
            this.SearchVM = new SearchTourLogViewModel(this.Tours.Count == 0 ? null : this.Tours[0].Logs);
        }

        public ICommand DeleteCommand => deleteCommand ??= new BaseCommand(this._deleteLogCommand.Execute);
        public ICommand NavigateCommand => navigateToTourLogFormCommand ??= new BaseCommand(this._navigateToTourLogFormCommand.Execute);
        public ICommand GenerateNormalReportCommand => generateNormalReportCommand ??= new BaseCommand(this._generateNormalReportCommand.Execute);
    }
}