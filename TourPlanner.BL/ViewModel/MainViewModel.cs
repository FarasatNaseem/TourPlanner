using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.Client.BL.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        //public ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            this.SelectedViewModel = new HomeViewModel(this);
        }

        //public BaseViewModel HomeVM { get; }
        
        //public BaseViewModel AddTourVM { get; }

        //public BaseViewModel AddTourLogVM { get; }

        //public MainViewModel()
        //{
        //    this.HomeVM = new HomeViewModel();
        //    this.AddTourVM = new AddTourViewModel();
        //    this.AddTourLogVM = new AddTourLogViewModel();
        //}
    }
}
