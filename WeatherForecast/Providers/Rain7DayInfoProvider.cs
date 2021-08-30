using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.Models;
using WeatherForecast.Providers.Interface;
using WeatherForecast.Services.Interface;

namespace WeatherForecast.Providers
{
    public class Rain7DayInfoProvider : IRain7DayInfoProvider
    {
        private readonly IWeatherForecastService _weatherForeCastService;

        public Rain7DayInfoProvider(IWeatherForecastService weatherForeCastService)
        {
            _weatherForeCastService = weatherForeCastService;
        }

        public async Task<string> GetDeviceInfoAsync()
        {
            var result = await _weatherForeCastService.GetStations();

            var device = new Device();
            if (result == null && result.WeatherInfo == null)
            {
                device.HasNoData = true;
                return JsonConvert.SerializeObject(device);
            }

            device = new Device
            {
                HasNoData = false,
                DeviceInformation = result.WeatherInfo.Select(x => new DeviceInfo
                {
                    DeviceName = x.Info.DeviceName,
                    DeviceID = x.Info.DeviceId,
                    Firmware = x.Info.Firmware,
                    Hardware = x.Info.Hardware,
                    Rain7DayInfo = new Rain7Dayinfo
                    {
                        Sum = x.Meta.Rain7d.Sum,
                        Vals = x.Meta.Rain7d.Vals
                    }
                }).ToList()
            };
            return JsonConvert.SerializeObject(device);
        }

        public async Task<string> GetDeviceInfoAsync(int deviceID)
        {
            var result = await _weatherForeCastService.GetStations();

            var device = new Device();
            if (result == null && result.WeatherInfo == null)
            {
                device.HasNoData = true;
                return JsonConvert.SerializeObject(device);
            }

            device = new Device
            {
                HasNoData = false,
                DeviceInformation = result.WeatherInfo.Where(wi => wi.Info.DeviceId == deviceID).Select(x => new DeviceInfo
                {
                    DeviceName = x.Info.DeviceName,
                    DeviceID = x.Info.DeviceId,
                    Firmware = x.Info.Firmware,
                    Hardware = x.Info.Hardware,
                    Rain7DayInfo = new Rain7Dayinfo
                    {
                        Sum = x.Meta.Rain7d.Sum,
                        Vals = x.Meta.Rain7d.Vals
                    }
                }).ToList()
            };

            return JsonConvert.SerializeObject(device);
        }
    }
}