using System.Windows.Input;
using TourPlanner.Client.BL.Command;

namespace TourPlanner.Client.BL.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        public BaseViewModel TourVM { get; }
        public BaseViewModel TourLogVM { get; }

        public BaseViewModel HeaderVM { get; }

        private BaseViewModel _selectedViewModel;
        private MainViewModel mainViewModel;

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        
        public HomeViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            this.TourLogVM = new TourLogViewModel(mainViewModel);
            this.TourVM = new TourViewModel(this.TourLogVM, mainViewModel);
            this.HeaderVM = new HeaderViewModel(mainViewModel);
        }
    }
}