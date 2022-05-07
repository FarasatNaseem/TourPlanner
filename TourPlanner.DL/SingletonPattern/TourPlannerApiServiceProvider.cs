namespace TourPlanner.Client.DL.SingletonPattern
{
    using TourPlanner.Client.DL.Services;
    public static class TourPlannerApiServiceProvider
    {
        static TourPlannerApiServiceProvider()
        {
            TourService = new TourService();
            TourLogService = new TourLogService();
        }

        public static AbstractService TourService { get; }
        public static AbstractService TourLogService { get; }
    }
}