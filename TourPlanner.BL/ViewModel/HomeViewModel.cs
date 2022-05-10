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