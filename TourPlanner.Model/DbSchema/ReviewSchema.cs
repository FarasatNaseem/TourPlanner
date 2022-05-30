namespace TourPlanner.Model.DbSchema
{
    public class ReviewSchema
    {
        public ReviewSchema(string name, string feedback)
        {
            this.Name = name;
            this.Feedback = feedback;
        }

        public int Id { get; }
        public string Name { get; }
        public string Feedback { get; }
    }
}
