using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourPlanner.Model;

namespace TourPlanner.API.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class TourController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Tour> Get()
        {
            throw new NotFiniteNumberException();
        }

        [HttpPost]
        public IEnumerable<Tour> Post(object tourData)
        {

            throw new NotFiniteNumberException();
        }
    }
}
