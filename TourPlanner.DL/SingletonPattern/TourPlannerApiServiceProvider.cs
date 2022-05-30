namespace TourPlanner.Client.DL.SingletonPattern
{
    using TourPlanner.Client.DL.Services;
    public static class TourPlannerApiServiceProvider
    {
        static TourPlannerApiServiceProvider()
        {
            TourService = new TourService();
            TourLogService = new TourLogService();
            ReviewService = new ReviewService();
        }

        public static AbstractService TourService { get; }
        public static AbstractService TourLogService { get; }
        public static AbstractService ReviewService { get; }
    }
}