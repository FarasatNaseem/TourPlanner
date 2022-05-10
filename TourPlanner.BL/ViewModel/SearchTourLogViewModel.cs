using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.Command;
using TourPlanner.Client.BL.Wrapper;

namespace TourPlanner.Client.BL.ViewModel
{
    public class SearchTourLogViewModel : BaseViewModel
    {
        private string _text;
        public ITourPlannerCommand _searchTourLogCommand;
        public SearchTourLogViewModel(ObservableCollection<TourLogWrapper> tourLogs)
        {
            this.TourLogs = tourLogs;
            this._searchTourLogCommand = new SearchTourLogCommand(tourLogs);
        }
        public ObservableCollection<TourLogWrapper> TourLogs { get; set; }

        public string Text
        {
            get => _text;
            set
            {
                if (_text == value)
                {
                    return;
                }

                _text = value;

                OnPropertyChanged();
                this._searchTourLogCommand.Execute(_text);
            }
        }
    }
}
