using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ForumApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        //private readonly ILogger<HomeController> _logger;

        /*public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }*/

        [HttpGet]
        public String Get()
        {
            return "Hi";
        }
    }
}
