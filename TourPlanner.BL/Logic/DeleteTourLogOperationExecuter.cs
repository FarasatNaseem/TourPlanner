﻿namespace TourPlanner.Client.BL.Logic
{
    using System.Collections.ObjectModel;
    using TourPlanner.Client.BL.Wrapper;
    using TourPlanner.Client.DL;
    using TourPlanner.Client.DL.Services;

    public class DeleteTourLogOperationExecuter : IOperationExecuter<int>
    {
        // Test starts

        private TourPlannerApi api = new TourPlannerApi(new TourLogService());

        // Test ends

        private ObservableCollection<TourWrapper> _tours;
        public DeleteTourLogOperationExecuter(ObservableCollection<TourWrapper> tours)
        {
            this._tours = tours;

        }
        public void Execute(int parameter)
        {
            //api.TourLogService.Delete(parameter);

            for (int tourIndex = 0; tourIndex < this._tours.Count; tourIndex++)
            {
                for (int logIndex = 0; logIndex < this._tours[tourIndex].Logs.Count; logIndex++)
                {
                    if (this._tours[tourIndex].Logs[logIndex].PrimaryKey == parameter)
                    {
                        this._tours[tourIndex].Logs.RemoveAt(logIndex);
                    }
                }
            }
        }
    }
}
