using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherForecast.Models
{
    public class WeatherInfoModel
    {
        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("rights")]
        public string Rights { get; set; }

        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("dates")]
        public Dates Dates { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }
    }

    public class Name
    {
        [JsonProperty("original")]
        public string Original { get; set; }

        [JsonProperty("custom")]
        public string Custom { get; set; }
    }

    public class Info
    {
        [JsonProperty("device_id")]
        public string DeviceID { get; set; }

        [JsonProperty("device_name")]
        public string DeviceName { get; set; }

        [JsonProperty("hardware")]
        public string Hardware { get; set; }

        [JsonProperty("firmware")]
        public string Firmware { get; set; }
    }

    public class Dates
    {
        [JsonProperty("min_date")]
        public string MinDate { get; set; }

        [JsonProperty("max_date")]
        public string MaxDate { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("last_communication")]
        public string LastCommunication { get; set; }
    }

    public class Position
    {
        [JsonProperty("altitude")]
        public string Altitude { get; set; }

        [JsonProperty("geo")]
        public Geo Geo { get; set; }
    }

    public class Geo
    {
        [JsonProperty("coordinates")]
        public List<string> Coordinates { get; set; }
    }
}