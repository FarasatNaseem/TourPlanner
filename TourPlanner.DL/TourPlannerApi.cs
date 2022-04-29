using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.DL.Services;

namespace TourPlanner.Client.DL
{
    public class TourPlannerApi
    {
        public TourPlannerApi(TourService tourService)
        {
            this.TourService = tourService;
        }

        public TourPlannerApi(TourLogService tourLogService)
        {
            this.TourLogService = tourLogService;
        }

        public IService TourService { get; }
        public IService TourLogService { get; }
    }
}
