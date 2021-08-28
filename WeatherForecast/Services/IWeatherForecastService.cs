using System.Threading.Tasks;

namespace WeatherForecast.Services
{
    public interface IWeatherForecastService
    {
        Task<string> GetStations();

        Task<string> GetStationWithID(string stationID);
    }
}