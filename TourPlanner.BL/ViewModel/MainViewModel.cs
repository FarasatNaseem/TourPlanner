using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.BL.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public BaseViewModel TourVM { get; }
        public BaseViewModel TourLogVM { get; }

        public MainViewModel()
        {
            this.TourLogVM = new TourLogViewModel();
            this.TourVM = new TourViewModel(this.TourLogVM);
        }
    }
}
