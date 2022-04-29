namespace TourPlanner.BL.Logic
{
    using System.Collections.ObjectModel;
    using TourPlanner.BL.Wrapper;

    public class DeleteTourLogOperationExecuter : IOperationExecuter<int>
    {
        private ObservableCollection<TourWrapper> _tours;
        public DeleteTourLogOperationExecuter(ObservableCollection<TourWrapper> tours)
        {
            this._tours = tours;

        }
        public void Execute(int parameter)
        {
            for (int tourIndex = 0; tourIndex < this._tours.Count; tourIndex++)
            {
                for (int logIndex = 0; logIndex < this._tours[tourIndex].Logs.Count; logIndex++)
                {
                    if (this._tours[tourIndex].Logs[logIndex].PrimaryKey == parameter)
                    {
                        this._tours[tourIndex].Logs.RemoveAt(logIndex);
                    }
                }
            }
        }
    }
}
