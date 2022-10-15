using Microsoft.AspNetCore.Mvc;

namespace AverageTemperatureApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AverageTemperatureController : ControllerBase
    {
        [HttpGet(Name = "GetTemperature")]
        public string Get()
        {
            return "todo";
        }
    }
}
