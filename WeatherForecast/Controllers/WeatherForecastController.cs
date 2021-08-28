using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WeatherForecast.Services;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForeCastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IWeatherForecastService weatherForeCastService)
        {
            _logger = logger;
            _weatherForeCastService = weatherForeCastService;
        }

        [HttpGet("StationList")]
        public async Task<IActionResult> Stations()
        {
            var result = await _weatherForeCastService.GetStations();
            return Ok(result);
        }

        [HttpGet("StationListWithID")]
        public async Task<IActionResult> StationWithID([FromQuery(Name = "stationID")] string stationID)
        {
            var result = await _weatherForeCastService.GetStationWithID(stationID);

            return Ok(result);
        }
    }
}