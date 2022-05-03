using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourPlanner.API.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class TourLogController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            throw new NotFiniteNumberException();
        }

        [HttpPost]
        public IEnumerable<WeatherForecast> Post(object tourData)
        {

            throw new NotFiniteNumberException();
        }
    }
}
