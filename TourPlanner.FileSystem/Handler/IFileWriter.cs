using System.Threading.Tasks;

namespace TourPlanner.FileSystem.Handler
{
    public interface IFileWriter
    {
        Task<(bool, string)> Write(string filePath, string serializedData);
    }
}
