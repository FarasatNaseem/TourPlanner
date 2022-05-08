namespace TourPlanner.Client.BL.Logic
{
    using Nito.AsyncEx;
    using System.Collections.ObjectModel;
    using TourPlanner.Client.BL.Wrapper;
    using TourPlanner.Client.DL;
    using TourPlanner.Client.DL.Responses;
    using TourPlanner.Client.DL.Services;
    using TourPlanner.Client.DL.SingletonPattern;

    public class DeleteTourLogOperationExecuter : IOperationExecuter<int>
    {

        private ObservableCollection<TourWrapper> _tours;
        public DeleteTourLogOperationExecuter(ObservableCollection<TourWrapper> tours)
        {
            this._tours = tours;

        }
        public void Execute(int parameter)
        {
            // Delete from database.
            GenericApiResponse response = AsyncContext.Run(() => TourPlannerApiServiceProvider.TourLogService.Delete(parameter));

            if (response.IsCorrectlyResponded)
            {
                // Delete locally.
                this.DeleteLogsLocally(parameter);
            }
        }

        private void DeleteLogsLocally(int id)
        {
            for (int tourIndex = 0; tourIndex < this._tours.Count; tourIndex++)
            {
                for (int logIndex = 0; logIndex < this._tours[tourIndex].Logs.Count; logIndex++)
                {
                    if (this._tours[tourIndex].Logs[logIndex].Id == id)
                    {
                        this._tours[tourIndex].Logs.RemoveAt(logIndex);
                    }
                }
            }
        }
    }
}
