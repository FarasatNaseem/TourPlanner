using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.Client.DL.Services
{
    public interface IPutService
    {
        Task<(bool, string)> Update(object listOfUpdatedData);
    }
}
