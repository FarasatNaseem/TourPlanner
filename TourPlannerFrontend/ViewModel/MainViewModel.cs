using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlannerFrontend.Model;

namespace TourPlannerFrontend.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public BaseViewModel TourListVM { get; }
        public BaseViewModel TourLogsVM { get; }

        public MainViewModel()
        {
            this.TourLogsVM = new TourLogViewModel();
            this.TourListVM = new TourListViewModel(this.TourLogsVM);
        }
    }
}
