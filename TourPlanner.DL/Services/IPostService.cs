using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Client.DL.Responses;

namespace TourPlanner.Client.DL.Services
{
    public interface IPostService
    {
        Task<GenericApiResponse> Create(object dataToStoreInDB);
        Task<GenericApiResponse> Import(object dataToStoreInDB);
    }
}
