using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherForecast.DataAccess;
using WeatherForecast.Entities;
using WeatherForecast.Handlers;
using WeatherForecast.Services.Interface;

namespace WeatherForecast.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly WeatherInfoDBContext _weatherInfoDBContext;

        public WeatherForecastService(WeatherInfoDBContext weatherInfoDBContext)
        {
            _weatherInfoDBContext = weatherInfoDBContext;
        }

        public async Task<Weather> GetStations()
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
                var data = JsonConvert.DeserializeObject<List<WeatherInfo>>(result);
                var weather = new Weather
                {
                    WeatherInfo = data
                };
                return weather;
            }

            return null;
        }
    }
}