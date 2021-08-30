using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherForecast.DataAccess;
using WeatherForecast.Handlers;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly WeatherInfoDBContext _weatherInfoDBContext;

        public WeatherForecastService(WeatherInfoDBContext weatherInfoDBContext)
        {
            _weatherInfoDBContext = weatherInfoDBContext;
        }

        public async Task<string> GetStations()
        {
            var httpHandler = new MetosHttpHandler(new HttpClientHandler())
            {
                PublicKey = "2e619f3c578dd3ca6f8a9157049c23a8f3e0e83ae894b521",
                PrivateKey = "bdb533575fe013385b0d7b6783c1da7e9e885f0db75a4278"
            };
            var httpClient = new HttpClient(httpHandler) { BaseAddress = httpHandler.ApiUri };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync("/user/stations");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                //var weatherInfo = new WeatherInfo
                //{
                //    Weather = "test"
                //};
                var data = JsonConvert.DeserializeObject<List<WeatherInfo>>(result);
                var dt = new Weather
                {
                    WeatherInfo = data
                };
                //await _weatherInfoDBContext.Weather.AddAsync(data);
                //await _weatherInfoDBContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<string> GetStationWithID(string stationID)
        {
            var httpHandler = new MetosHttpHandler(new HttpClientHandler())
            {
                PublicKey = "2e619f3c578dd3ca6f8a9157049c23a8f3e0e83ae894b521",
                PrivateKey = "bdb533575fe013385b0d7b6783c1da7e9e885f0db75a4278"
            };
            var httpClient = new HttpClient(httpHandler) { BaseAddress = httpHandler.ApiUri };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync("/user/stations");
            var result = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<List<WeatherInfoModel>>(result);

            var stationIDInfo = data.Where(dt => dt.Name.Original.ToUpper() == stationID.ToUpper()).FirstOrDefault();
            if (stationIDInfo != null)
            {
                return JsonConvert.SerializeObject(stationIDInfo);
            }
            return null;
        }
    }
}