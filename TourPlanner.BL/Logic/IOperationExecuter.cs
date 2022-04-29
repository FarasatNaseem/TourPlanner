namespace TourPlanner.BL.Logic
{
    public interface IOperationExecuter<Parameter> 
    {
        void Execute(Parameter parameter);
    }
}
