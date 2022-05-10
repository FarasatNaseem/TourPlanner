using System.Threading.Tasks;

namespace TourPlanner.FileSystem.Handler
{
    public interface IFileReader
    {
        Task<(string, string)> Read(string filePath);
    }
}
