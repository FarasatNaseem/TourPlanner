using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
namespace TourPlanner.Client.DL.Services
{
    public interface IGetService
    {
        Task<(object, string)> Read(int idOfData);

        Task<(object, string)> ReadAll();
    }
}
