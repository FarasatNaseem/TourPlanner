using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlanner.Client.BL.Command;
using TourPlanner.Client.BL.Wrapper;

namespace TourPlanner.Client.BL.ViewModel
{
    public class SearchTourViewModel : BaseViewModel
    {
        private string _text;
        private ObservableCollection<TourWrapper> _tours;
        private ITourPlannerCommand _searchTourCommand;
        public SearchTourViewModel(ObservableCollection<TourWrapper> tours)
        {
            this._tours = tours;
            this._searchTourCommand = new SearchTourCommand(tours);
        }

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
                this._searchTourCommand.Execute(_text);
            }
        }
    }
}
