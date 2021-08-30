using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.DataAccess;
using WeatherForecast.Providers.Interface;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRain7DayInfoProvider _rain7DayinfoProvider;
        private readonly WeatherInfoDBContext _weatherInfoDBContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            WeatherInfoDBContext weatherInfoDBContext,
            IRain7DayInfoProvider rain7DayinfoProvider)
        {
            _logger = logger;
            _weatherInfoDBContext = weatherInfoDBContext;
            _rain7DayinfoProvider = rain7DayinfoProvider;
        }

        [HttpGet("DeviceInfo")]
        public async Task<IActionResult> GetDeviceInfo()
        {
            var deviceInfo = await _rain7DayinfoProvider.GetDeviceInfoAsync();
            if (deviceInfo != null)
            {
                var t = _weatherInfoDBContext.Weather.ToList();
                return Ok(deviceInfo);
            }
            return NotFound();
        }

        [HttpGet("DeviceInfoWithID")]
        public async Task<IActionResult> GetDeviceInfoWithID([FromQuery(Name = "deviceID")] int deviceID)
        {
            var deviceInfo = await _rain7DayinfoProvider.GetDeviceInfoAsync(deviceID);
            if (deviceInfo != null)
                return Ok(deviceInfo);
            return NotFound();
        }
    }
}