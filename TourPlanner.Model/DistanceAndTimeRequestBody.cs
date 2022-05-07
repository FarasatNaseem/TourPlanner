namespace TourPlanner.Model
{

    public class DistanceAndTimeRequestBody
    {
        public DistanceAndTimeRequestBody(Location locations, string option)
        {
            this.Locations = locations;
            this.Option = option;
        }
        public Location Locations { get; }
        public string Option { get; }
    }
}
