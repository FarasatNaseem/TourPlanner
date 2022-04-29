using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TourPlanner.BL.ViewModel;
using TourPlanner.BL.Wrapper;

namespace TourPlanner.BL.Logic
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
            tourLogViewModel.Tours.Add(this._tours[parameter]);
        }
    }
}
