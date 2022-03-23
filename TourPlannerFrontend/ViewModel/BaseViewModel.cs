namespace TourPlannerFrontend.ViewModel
{
    using System.ComponentModel;
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyToChange)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyToChange));
        }
    }
}
