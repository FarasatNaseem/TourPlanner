using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.Client.BL.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public BaseViewModel HomeVM { get; }
        
        public BaseViewModel AddTourVM { get; }

        public BaseViewModel AddTourLogVM { get; }

        public MainViewModel()
        {
            this.HomeVM = new HomeViewModel();
            this.AddTourVM = new AddTourViewModel();
            this.AddTourLogVM = new AddTourLogViewModel();
        }
    }
}
