using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TourPlanner.Model;
using TourPlanner.Server.BL;
using System.Text.Json;
using Newtonsoft.Json;
using TourPlanner.Model.DbSchema;

namespace TourPlanner.API.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class TourController : ControllerBase
    {
        private readonly ServerOperationExecuter _serverOperationExecuter;

        public TourController()
        {
            this._serverOperationExecuter = new ServerOperationExecuter();
        }

        [HttpGet]

        public string Get()
        {
            var response = this._serverOperationExecuter.GetAllTourWithLogs();


            return JsonConvert.SerializeObject(response.Item1);
        }

        [HttpGet("{someText}")]
        public string Get(string someText)
        {
            var response = this._serverOperationExecuter.FilterTours(someText);

            return JsonConvert.SerializeObject(response.Item1);
        }


        [HttpPost]
        public ActionResult Post(object body)
        {
            string jsonTourData = body.ToString();

            try
            {
                var response = this._serverOperationExecuter.AddTour(jsonTourData);

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
                  "Error creating new tour");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var response = this._serverOperationExecuter.DeleteTourByID(id);

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
    }
}
