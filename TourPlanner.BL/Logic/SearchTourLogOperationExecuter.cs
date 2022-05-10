using Nito.AsyncEx;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.BL.Wrapper;
using TourPlanner.Client.DL.Responses;
using TourPlanner.Client.DL.SingletonPattern;
using TourPlanner.Model;
using TourPlanner.Model.DbSchema;

namespace TourPlanner.Client.BL.Logic
{
    public class SearchTourLogOperationExecuter : IOperationExecuter<ArrayList>
    {
        private ObservableCollection<TourLogWrapper> tourLogs;

        public SearchTourLogOperationExecuter(ObservableCollection<TourLogWrapper> tourLogs)
        {
            this.tourLogs = tourLogs;
        }

        public void Execute(ArrayList parameter)
        {
            GenericApiResponse response = AsyncContext.Run(() => TourPlannerApiServiceProvider.TourLogService.ReadLike(parameter[0].ToString(), Convert.ToInt32(parameter[1])));

            this.tourLogs.Clear();

            if (response.Data != null)
            {
                foreach (var tourLog in (List<TourLogSchema>)response.Data)
                {
                    this.tourLogs.Add(new TourLogWrapper(new TourLog(tourLog.Id, tourLog.TourId, tourLog.DateTime, tourLog.Comment, tourLog.Difficulty, tourLog.TotalDuration, tourLog.Rating)));
                }
            }
        }
    }
}