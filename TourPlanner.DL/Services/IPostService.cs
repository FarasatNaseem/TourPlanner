using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.Client.DL.Services
{
    public interface IPostService
    {
        Task<(bool, string)> Create(object dataToStoreInDB);
    }
}
