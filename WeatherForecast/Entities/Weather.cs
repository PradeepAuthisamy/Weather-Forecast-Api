using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherForecast.Entities
{
    public class Config
    {
        [JsonProperty("timezone_offset")]
        public int TimezoneOffset { get; set; }
    }

    public class Dates
    {
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("last_communication")]
        public string LastCommunication { get; set; }

        [JsonProperty("max_date")]
        public string Maxdate { get; set; }

        [JsonProperty("min_date")]
        public string Mindate { get; set; }
    }

    public class Geo
    {
        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }
    }

    public class Info
    {
        [JsonProperty("device_id")]
        public int DeviceId { get; set; }

        [JsonProperty("device_name")]
        public string DeviceName { get; set; }

        [JsonProperty("firmware")]
        public double Firmware { get; set; }

        [JsonProperty("hardware")]
        public double Hardware { get; set; }
    }

    public class Meta
    {
        [JsonProperty("airTemp")]
        public double? AirTemp { get; set; }

        [JsonProperty("battery")]
        public int Battery { get; set; }

        [JsonProperty("lw")]
        public int Lw { get; set; }

        [JsonProperty("rain24h")]
        public Rain24h Rain24h { get; set; }

        [JsonProperty("rain48h")]
        public Rain48h Rain48h { get; set; }

        [JsonProperty("rain7d")]
        public Rain7d Rain7d { get; set; }

        [JsonProperty("rh")]
        public double? Rh { get; set; }

        [JsonProperty("soilTemp")]
        public double SoilTemp { get; set; }

        [JsonProperty("solarPanel")]
        public int SolarPanel { get; set; }

        [JsonProperty("solarRadiation")]
        public double SolarRadiation { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }
    }

    public class Name
    {
        [JsonProperty("custom")]
        public string Custom { get; set; }

        [JsonProperty("original")]
        public string Original { get; set; }
    }
    public class Position
    {
        [JsonProperty("altitude")]
        public double Altitude { get; set; }

        [JsonProperty("geo")]
        public Geo Geo { get; set; }
    }
    public class Rain24h
    {
        [JsonProperty("sum")]
        public double Sum { get; set; }

        [JsonProperty("vals")]
        public List<double> Vals { get; set; }
    }

    public class Rain48h
    {
        [JsonProperty("sum")]
        public double Sum { get; set; }

        [JsonProperty("vals")]
        public List<double> Vals { get; set; }
    }

    public class Rain7d
    {
        [JsonProperty("sum")]
        public double Sum { get; set; }

        [JsonProperty("vals")]
        public List<double> Vals { get; set; }
    }
    public class Weather
    {
        public List<WeatherInfo> WeatherInfo { get; set; }
    }

    public class WeatherInfo
    {
        [JsonProperty("config")]
        public Config Config { get; set; }

        [JsonProperty("dates")]
        public Dates Dates { get; set; }

        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("licenses")]
        public bool Licenses { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }

        [JsonProperty("rights")]
        public string Rights { get; set; }
    }
}