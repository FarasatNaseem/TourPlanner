namespace TourPlanner.BL.Command
{
    public interface ITourPlannerCommand
    {
        void Execute(object commandParameter);
    }
}
