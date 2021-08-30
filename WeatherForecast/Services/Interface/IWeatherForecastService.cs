using System.Threading.Tasks;
using WeatherForecast.Entities;

namespace WeatherForecast.Services.Interface
{
    public interface IWeatherForecastService
    {
        Task<Weather> GetStations();
    }
}