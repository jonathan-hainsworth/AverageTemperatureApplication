using AverageTemperatureApplication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AverageTemperatureApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AverageTemperatureController : ControllerBase
    {
        private IAverageTemperatureService _averageTemperatureService;

        public AverageTemperatureController(IAverageTemperatureService averageTemperatureService)
        {
            _averageTemperatureService = averageTemperatureService;
        }

        [HttpGet(Name = "GetTemperatureLastFiveDays")]
        public ActionResult<AverageTemperatureResponse> Get(double latitude, double longitude, Guid apiKey)
        {
            throw new NotImplementedException();
        }
    }
}
