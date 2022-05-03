using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.Client.BL.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        public BaseViewModel TourVM { get; }
        public BaseViewModel TourLogVM { get; }

        public HomeViewModel()
        {
            this.TourLogVM = new TourLogViewModel();
            this.TourVM = new TourViewModel(this.TourLogVM);
        }
    }
}