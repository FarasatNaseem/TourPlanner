using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlanner.Client.BL.Command;

namespace TourPlanner.Client.BL.ViewModel
{
    public class HeaderViewModel : BaseViewModel
    {

        private BaseCommand importCommand;
        private BaseCommand exportCommand;
        private BaseCommand updateViewCommand;
        private BaseViewModel selectedViewModel;

        private ITourPlannerCommand _importTourCommand;
        private ITourPlannerCommand _exportTourCommnad;
        private ITourPlannerCommand _updateViewCommand;

        public HeaderViewModel(MainViewModel mainViewModel)
        {
            this._importTourCommand = new ImportTourCommand();
            this._exportTourCommnad = new ExportTourCommand();
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

        public ICommand UpdateViewCommand => updateViewCommand ??= new BaseCommand(this._updateViewCommand.Execute);

        public ICommand ImportCommand => importCommand ??= new BaseCommand(this._importTourCommand.Execute);
        public ICommand ExportCommand => exportCommand ??= new BaseCommand(this._exportTourCommnad.Execute);
    }
}
