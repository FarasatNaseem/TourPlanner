using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.ViewModel;
using TourPlanner.Client.BL.Wrapper;

namespace TourPlanner.Client.BL.Logic
{
    public class ShowTourLogOperationExecuter : IOperationExecuter<int>
    {
        private readonly BaseViewModel _tourLogViewModel;
        private ObservableCollection<TourWrapper> _tours;
        public ShowTourLogOperationExecuter(BaseViewModel tourLogViewModel, ObservableCollection<TourWrapper> tours)
        {
            this._tourLogViewModel = tourLogViewModel;
            this._tours = tours;

        }
        public void Execute(int parameter)
        {
            var tourLogViewModel = (TourLogViewModel)this._tourLogViewModel;
            tourLogViewModel.Tours.Clear();
            tourLogViewModel.Tours.Add(this._tours[parameter - 1]);
        }
    }
}
