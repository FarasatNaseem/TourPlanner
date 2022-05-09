namespace Report
{
    public abstract class AbstractReportGenerator<T> where T : class
    {
        public AbstractReportGenerator(string filePath)
        {
            this.FilePath = filePath;
        }
        protected string FilePath { get; }
        public abstract bool Generate(T reportData);
    }
}
