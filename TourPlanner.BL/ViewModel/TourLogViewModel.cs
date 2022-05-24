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
        private BaseCommand generateNormalReportCommand;
        private BaseCommand updateViewCommand;
        private BaseViewModel selectedViewModel;

        private ITourPlannerCommand _deleteLogCommand;
        private ITourPlannerCommand _generateNormalReportCommand;
        private ITourPlannerCommand _updateViewCommand;

        public ObservableCollection<TourWrapper> Tours { get; set; }
        public BaseViewModel SearchVM { get; set; }

        public TourLogViewModel(MainViewModel mainViewModel)
        {
            this.Tours = new ObservableCollection<TourWrapper>();
            this._deleteLogCommand = new DeleteTourLogCommand(this.Tours);
            this._generateNormalReportCommand = new GenerateNormalReportCommand();
            this.SearchVM = new SearchTourLogViewModel(this.Tours.Count == 0 ? null : this.Tours[0].Logs);
            this._updateViewCommand = new UpdateViewCommand(mainViewModel);
        }

        public BaseViewModel SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand DeleteCommand => deleteCommand ??= new BaseCommand(this._deleteLogCommand.Execute);
        public ICommand GenerateNormalReportCommand => generateNormalReportCommand ??= new BaseCommand(this._generateNormalReportCommand.Execute);
        public ICommand UpdateViewCommand => updateViewCommand ??= new BaseCommand(this._updateViewCommand.Execute);
    }
}