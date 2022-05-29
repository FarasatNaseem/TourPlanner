using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.ViewModel;
using TourPlanner.Client.DL.Responses;
using TourPlanner.Client.DL.SingletonPattern;
using TourPlanner.Model.DbSchema;

namespace TourPlanner.Client.BL.Logic
{
    public class FetchSpecificTourLogOperationExecuter : IOperationExecuter<int>
    {
        private readonly UpdateTourLogViewModel _updateTourLogViewModel;
        public FetchSpecificTourLogOperationExecuter(UpdateTourLogViewModel updateTourLogViewModel)
        {
            this._updateTourLogViewModel = updateTourLogViewModel;
        }

        public void Execute(int parameter)
        {
            try
            {
                GenericApiResponse response = AsyncContext.Run(() => TourPlannerApiServiceProvider.TourLogService.Read(parameter));

                var tourLogData = (TourLogSchema)response.Data;

                this._updateTourLogViewModel.Rating = tourLogData.Rating;
                this._updateTourLogViewModel.Difficulty = tourLogData.Difficulty;
                this._updateTourLogViewModel.DateTime = tourLogData.DateTime;
                this._updateTourLogViewModel.Comment = tourLogData.Comment;
                this._updateTourLogViewModel.TotalDuration = tourLogData.TotalDuration;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
