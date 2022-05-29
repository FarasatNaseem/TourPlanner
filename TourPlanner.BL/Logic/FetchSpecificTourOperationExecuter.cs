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
    public class FetchSpecificTourOperationExecuter : IOperationExecuter<int>
    {
        private readonly UpdateTourViewModel _updateTourViewModel;
        public FetchSpecificTourOperationExecuter(UpdateTourViewModel updateTourViewModel)
        {
            this._updateTourViewModel = updateTourViewModel;
        }

        public void Execute(int parameter)
        {
            try
            {
                GenericApiResponse response = AsyncContext.Run(() => TourPlannerApiServiceProvider.TourService.Read(parameter));

                var tourData = (TourSchemaWithoutLog)response.Data;

                this._updateTourViewModel.Name = tourData.Name;
                this._updateTourViewModel.From = tourData.From;
                this._updateTourViewModel.To = tourData.To;
                this._updateTourViewModel.Description = tourData.TourDescription;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
