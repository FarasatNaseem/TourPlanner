using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourPlanner.Server.BL;

namespace TourPlanner.API.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class TourLogController : ControllerBase
    {
        private readonly ServerOperationExecuter _serverOperationExecuter;

        public TourLogController()
        {
            this._serverOperationExecuter = new ServerOperationExecuter();
        }


        [HttpGet("{someText}/{id}")]
        public string Get(string someText, int id)
        {
            var response = this._serverOperationExecuter.FilterTourLogs(someText, id);

            return JsonConvert.SerializeObject(response.Item1);
        }


        [HttpPost]
        public ActionResult Post(object body)
        {
            string jsonTourLogData = body.ToString();

            try
            {
                var response = this._serverOperationExecuter.AddTourLog(jsonTourLogData);

                if (response.Item2 == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                 "Invalid data");
                }

                return StatusCode(StatusCodes.Status200OK,
                  response.Item2);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error creating new employee record");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var response = this._serverOperationExecuter.DeleteTourLogByID(id);

                if (!response.Item1)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                response.Item2);
                }

                return StatusCode(StatusCodes.Status200OK,
                  response.Item2);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error deleting tour record");
            }
        }

        [HttpPut]
        public ActionResult Put(object body)
        {
            string jsonTourData = body.ToString();

            try
            {
                var response = this._serverOperationExecuter.UpdateTourLog(jsonTourData);

                if (response.Item2 == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                 "Invalid data");
                }

                return StatusCode(StatusCodes.Status200OK,
                  response.Item2);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error updating tour log");
            }

        }
    }
}
