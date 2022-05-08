namespace TourPlanner.Client.BL.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using TourPlanner.Client.BL.Command;
    using TourPlanner.Client.BL.Wrapper;
    using TourPlanner.Model;

    public class TourViewModel : BaseViewModel
    {
        private BaseCommand deleteCommand;
        private BaseCommand showLogCommand;
        private BaseCommand loadCommand;
        private BaseCommand navigateToTourFormCommand;

        private readonly BaseViewModel _tourLogsVM;
        private ITourPlannerCommand _showLogCommand;
        private ITourPlannerCommand _loadTourCommand;
        private ITourPlannerCommand _navigateToTourFormCommand;
        private ITourPlannerCommand _deleteTourCommand;

        public TourViewModel(BaseViewModel tourLogsVM)
        {
            this._tourLogsVM = tourLogsVM;
            this.Tours = new ObservableCollection<TourWrapper>();
            this._showLogCommand = new ShowTourLogCommand(this._tourLogsVM, this.Tours);
            this._loadTourCommand = new LoadTourCommand(this);
            this._navigateToTourFormCommand = new NavigateToTourFormCommand();
            this._deleteTourCommand = new DeleteTourCommand(this.Tours, this._tourLogsVM);
        }

        public ObservableCollection<TourWrapper> Tours { get; }

        public ICommand DeleteCommand => deleteCommand ??= new BaseCommand(this._deleteTourCommand.Execute);

        public ICommand ShowLogCommand => showLogCommand ??= new BaseCommand(this._showLogCommand.Execute);

        public ICommand LoadCommand => loadCommand ??= new BaseCommand(this._loadTourCommand.Execute);

        public ICommand NavigateCommand => navigateToTourFormCommand ??= new BaseCommand(this._navigateToTourFormCommand.Execute);
    }
}