using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.DataAccess;
using WeatherForecast.Services;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForeCastService;
        private readonly WeatherInfoDBContext _weatherInfoDBContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IWeatherForecastService weatherForeCastService, WeatherInfoDBContext weatherInfoDBContext)
        {
            _logger = logger;
            _weatherForeCastService = weatherForeCastService;
            _weatherInfoDBContext = weatherInfoDBContext;
        }

        [HttpGet("StationList")]
        public async Task<IActionResult> Stations()
        {
            var result = null as List<WeatherInfo>; // await _weatherInfoDBContext.Weather.ToListAsync();
            if (result == null || !result.Any())
            {
                var data = await _weatherForeCastService.GetStations();
                if (data != null)
                {
                    return Ok(data);
                }
            }

            return NotFound();
        }

        [HttpGet("StationListWithID")]
        public async Task<IActionResult> StationWithID([FromQuery(Name = "stationID")] string stationID)
        {
            var result = await _weatherForeCastService.GetStationWithID(stationID);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}