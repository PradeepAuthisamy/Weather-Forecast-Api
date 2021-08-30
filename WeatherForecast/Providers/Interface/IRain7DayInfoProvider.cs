using System.Threading.Tasks;

namespace WeatherForecast.Providers.Interface
{
    public interface IRain7DayInfoProvider
    {
        Task<string> GetDeviceInfoAsync();

        Task<string> GetDeviceInfoAsync(int deviceID);
    }
}