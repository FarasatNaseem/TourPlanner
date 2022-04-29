namespace TourPlanner.Client.BL.Command
{
    public interface ITourPlannerCommand
    {
        void Execute(object commandParameter);
    }
}
