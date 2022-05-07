namespace TourPlanner.Model
{
    public class Location
    {
        public Location(string from, string to)
        {
            this.From = from;
            this.To = to;
        }
        public string From { get; }
        public string To { get; }
    }
}
