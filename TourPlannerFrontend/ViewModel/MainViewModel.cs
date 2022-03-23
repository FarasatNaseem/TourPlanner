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
        public BaseViewModel CurrentViewModel { get; }

        public MainViewModel()
        {
            this.CurrentViewModel = new TourListViewModel();
        }
    }
}
