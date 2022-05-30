namespace TourPlanner.Model
{
    public class Review
    {
        public Review(string name, string feedback)
        {
            this.Name = name;
            this.Feedback = feedback;
        }

        public string Name { get; }
        public string Feedback { get; }
    }
}