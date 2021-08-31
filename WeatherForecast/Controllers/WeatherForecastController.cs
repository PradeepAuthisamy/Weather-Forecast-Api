using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.DataAccess;
using WeatherForecast.Models;
using WeatherForecast.Providers.Interface;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IFeatureManager _featureManager;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRain7DayInfoProvider _rain7DayinfoProvider;
        private readonly WeatherInfoDBContext _weatherInfoDBContext;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            WeatherInfoDBContext weatherInfoDBContext,
            IRain7DayInfoProvider rain7DayinfoProvider,
            IFeatureManager featureManager)
        {
            _logger = logger;
            _weatherInfoDBContext = weatherInfoDBContext;
            _rain7DayinfoProvider = rain7DayinfoProvider;
            _featureManager = featureManager;
        }

        [HttpGet("DeviceInfo")]
        public async Task<IActionResult> GetDeviceInfo()
        {
            var isDBCallEnabled = await _featureManager.IsEnabledAsync("CallDB");
            var deviceInfo = await _rain7DayinfoProvider.GetDeviceInfoAsync(isDBCallEnabled);

            if (deviceInfo != null && isDBCallEnabled)
            {
                var data = _weatherInfoDBContext.Weather.ToList();
                var jsonResult = JsonConvert.SerializeObject(data);
                return Ok(jsonResult);
            }
            else
            {
                return Ok(deviceInfo);
            }
        }

        [HttpGet("DeviceInfoWithID")]
        public async Task<IActionResult> GetDeviceInfoWithID([FromQuery(Name = "deviceID")] int deviceID)
        {
            var isDBCallEnabled = await _featureManager.IsEnabledAsync("CallDB");
            var deviceInfo = await _rain7DayinfoProvider.GetDeviceInfoAsync(isDBCallEnabled);

            if (deviceInfo != null && isDBCallEnabled)
            {
                var data = _weatherInfoDBContext.Weather.Where(x => x.DeviceID == deviceID).ToList();
                var jsonResult = JsonConvert.SerializeObject(data);
                return Ok(jsonResult);
            }
            else
            {
                var data = JsonConvert.DeserializeObject<Device>(deviceInfo);
                var result = data.DeviceInformation.Where(x => x.DeviceID == deviceID).Select(x => x).ToList();
                var jsonResult = JsonConvert.SerializeObject(result);
                return Ok(jsonResult);
            }
        }
    }
}