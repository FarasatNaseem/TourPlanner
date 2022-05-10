using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.ViewModel;
using TourPlanner.Client.BL.Wrapper;
using TourPlanner.Client.DL.Responses;
using TourPlanner.Client.DL.SingletonPattern;

namespace TourPlanner.Client.BL.Logic
{
    public class DeleteTourOperationExecuter : IOperationExecuter<int>
    {
        private ObservableCollection<TourWrapper> _tours;
        private BaseViewModel _tourLogViewModel;
        public DeleteTourOperationExecuter(ObservableCollection<TourWrapper> tours, BaseViewModel tourLogViewModel)
        {
            this._tours = tours;
            this._tourLogViewModel = tourLogViewModel;
        }

        public void Execute(int parameter)
        {
            // Delete from database.
            GenericApiResponse response = AsyncContext.Run(() => TourPlannerApiServiceProvider.TourService.Delete(parameter));

            if (response.IsCorrectlyResponded)
            {
                // Delete locally.
                this.DeleteTourLocally(parameter);
                this.DeleteTourLogLocally(parameter);
            }
        }

        private void DeleteTourLocally(int id)
        {
            var tourIndex = this._tours.ToList().FindIndex(x => x.ID == id);

            this._tours.RemoveAt(tourIndex);
        }

        private void DeleteTourLogLocally(int tourId)
        {
            var tourLogVM = (TourLogViewModel)this._tourLogViewModel;

            if (tourLogVM.Tours.Count != 0)
            {
                var tourIndex = tourLogVM.Tours.ToList().FindIndex(x => x.ID == tourId);

                if (tourIndex != -1)
                {
                    tourLogVM.Tours.RemoveAt(tourIndex);
                }
            }
        }
    }
}
