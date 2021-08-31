using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.DataAccess;
using WeatherForecast.Models;
using WeatherForecast.Providers.Interface;
using WeatherForecast.Services.Interface;

namespace WeatherForecast.Providers
{
    public class Rain7DayInfoProvider : IRain7DayInfoProvider
    {
        private readonly IWeatherForecastService _weatherForeCastService;
        private readonly WeatherInfoDBContext _weatherInfoDBContext;

        public Rain7DayInfoProvider(IWeatherForecastService weatherForeCastService,
                                    WeatherInfoDBContext weatherInfoDBContext)
        {
            _weatherForeCastService = weatherForeCastService;
            _weatherInfoDBContext = weatherInfoDBContext;
        }

        public async Task<string> GetDeviceInfoAsync(bool isDBCallEnabled)
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
                    Name = x.Name.Original,
                    DeviceName = x.Info?.DeviceName,
                    DeviceID = x.Info?.DeviceId,
                    Firmware = x.Info?.Firmware,
                    Hardware = x.Info?.Hardware,
                    Rain7DayInfo = new Rain7Dayinfo
                    {
                        Name = x.Name.Original,
                        Sum = x.Meta?.Rain7d?.Sum,
                        Vals = x.Meta?.Rain7d?.Vals
                    }
                }).ToList()
            };

            if (isDBCallEnabled)
            {
                var t = _weatherInfoDBContext.Weather.ToList();
                _weatherInfoDBContext.Weather.RemoveRange(t.ToArray());
                await _weatherInfoDBContext.SaveChangesAsync();

                foreach (var deviceInfo in device.DeviceInformation)
                {
                    await _weatherInfoDBContext.Weather.AddAsync(deviceInfo);
                    await _weatherInfoDBContext.SaveChangesAsync();
                }
            }
            return JsonConvert.SerializeObject(device);
        }

        //public async Task<string> GetDeviceInfoAsync(int deviceID)
        //{
        //    var result = await _weatherForeCastService.GetStations();

        //    var device = new Device();
        //    if (result == null && result.WeatherInfo == null)
        //    {
        //        device.HasNoData = true;
        //        return JsonConvert.SerializeObject(device);
        //    }

        //    var filteredWithDeviceID = result.WeatherInfo.Where(wi => wi.Info.DeviceId == deviceID).Select(x => x);
        //    if (filteredWithDeviceID == null || !filteredWithDeviceID.Any())
        //    {
        //        device = new Device
        //        {
        //            HasNoData = false
        //        };
        //        return JsonConvert.SerializeObject(device);
        //    }

        //    device = new Device
        //    {
        //        HasNoData = false,
        //        DeviceInformation = filteredWithDeviceID.Where(wi => wi.Info.DeviceId == deviceID).Select(x => new DeviceInfo
        //        {
        //            Name = x.Name.Original,
        //            DeviceName = x.Info.DeviceName,
        //            DeviceID = x.Info?.DeviceId,
        //            Firmware = x.Info?.Firmware,
        //            Hardware = x.Info?.Hardware,
        //            Rain7DayInfo = new Rain7Dayinfo
        //            {
        //                Name = x.Name.Original,
        //                Sum = x.Meta?.Rain7d?.Sum,
        //                Vals = x.Meta?.Rain7d?.Vals
        //            }
        //        }).ToList()
        //    };

        //    foreach (var deviceInfo in device.DeviceInformation)
        //    {
        //        await _weatherInfoDBContext.Weather.AddAsync(deviceInfo);
        //        await _weatherInfoDBContext.SaveChangesAsync();
        //    }
        //    return JsonConvert.SerializeObject(device);
        //}
    }
}