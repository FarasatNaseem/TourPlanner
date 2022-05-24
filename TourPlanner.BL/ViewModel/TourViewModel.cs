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
        private BaseCommand updateViewCommand;
        private BaseViewModel selectedViewModel;


        private readonly BaseViewModel _tourLogsVM;
        private ITourPlannerCommand _showLogCommand;
        private ITourPlannerCommand _loadTourCommand;
        private ITourPlannerCommand _deleteTourCommand;
        private ITourPlannerCommand _updateViewCommand;


        private BaseCommand _importCommand;
        private BaseCommand _exportCommand;

        private ITourPlannerCommand _importTourCommand;
        private ITourPlannerCommand _exportTourCommnad;

        

        public TourViewModel(BaseViewModel tourLogsVM, MainViewModel mainViewModel)
        {
            this._tourLogsVM = tourLogsVM;
            this.Tours = new ObservableCollection<TourWrapper>();
            this._showLogCommand = new ShowTourLogCommand(this._tourLogsVM, this.Tours);
            this._loadTourCommand = new LoadTourCommand(this);
            this._loadTourCommand.Execute(null); // Fetch tours from database.

            this._deleteTourCommand = new DeleteTourCommand(this.Tours, this._tourLogsVM);

            this._updateViewCommand = new UpdateViewCommand(mainViewModel);

            this.SearchVM = new SearchTourViewModel(this.Tours);

            this._importTourCommand = new ImportTourCommand();

            this._exportTourCommnad = new ExportTourCommand();
        }

        public ObservableCollection<TourWrapper> Tours { get; }

        public BaseViewModel SearchVM { get; }

        public BaseViewModel SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand DeleteCommand => deleteCommand ??= new BaseCommand(this._deleteTourCommand.Execute);
        public ICommand ShowLogCommand => showLogCommand ??= new BaseCommand(this._showLogCommand.Execute);
        public ICommand LoadCommand => loadCommand ??= new BaseCommand(this._loadTourCommand.Execute);
        public ICommand UpdateViewCommand => updateViewCommand ??= new BaseCommand(this._updateViewCommand.Execute);
        public ICommand ImportCommand => _importCommand ??= new BaseCommand(this._importTourCommand.Execute);
        public ICommand ExportCommand => _exportCommand ??= new BaseCommand(this._exportTourCommnad.Execute);
    }
}