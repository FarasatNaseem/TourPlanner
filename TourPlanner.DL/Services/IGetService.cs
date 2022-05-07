namespace TourPlanner.Client.DL.Services
{
    using System.Threading.Tasks;
    using TourPlanner.Client.DL.Responses;

    public interface IGetService
    {
        Task<GenericApiResponse> Read(int id);
        Task<GenericApiResponse> ReadAll();
    }
}