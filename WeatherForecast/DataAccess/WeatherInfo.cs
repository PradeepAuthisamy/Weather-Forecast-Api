using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.DataAccess
{
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
        public int DeviceId { get; set; }

        [JsonProperty("device_name")]
        public string DeviceName { get; set; }

        [JsonProperty("hardware")]
        public double Hardware { get; set; }

        [JsonProperty("firmware")]
        public double Firmware { get; set; }
    }

    public class Dates
    {
        [JsonProperty("min_date")]
        public string Mindate { get; set; }

        [JsonProperty("max_date")]
        public string Maxdate { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("last_communication")]
        public string LastCommunication { get; set; }
    }

    public class Geo
    {
        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }
    }

    public class Position
    {
        [JsonProperty("altitude")]
        public double Altitude { get; set; }

        [JsonProperty("geo")]
        public Geo Geo { get; set; }
    }

    public class Config
    {
        [JsonProperty("timezone_offset")]
        public int TimezoneOffset { get; set; }
    }

    public class Rain7d
    {
        [JsonProperty("vals")]
        public List<double> Vals { get; set; }

        [JsonProperty("sum")]
        public double Sum { get; set; }
    }

    public class Rain48h
    {
        [JsonProperty("vals")]
        public List<double> Vals { get; set; }

        [JsonProperty("sum")]
        public double Sum { get; set; }
    }

    public class Rain24h
    {
        [JsonProperty("vals")]
        public List<double> Vals { get; set; }

        [JsonProperty("sum")]
        public double Sum { get; set; }
    }

    public class Meta
    {
        [JsonProperty("time")]
        public int Time { get; set; }

        [JsonProperty("battery")]
        public int Battery { get; set; }

        [JsonProperty("solarPanel")]
        public int SolarPanel { get; set; }

        [JsonProperty("solarRadiation")]
        public double SolarRadiation { get; set; }

        [JsonProperty("lw")]
        public int Lw { get; set; }

        [JsonProperty("soilTemp")]
        public double SoilTemp { get; set; }

        [JsonProperty("airTemp")]
        public double? AirTemp { get; set; }

        [JsonProperty("rh")]
        public double? Rh { get; set; }

        [JsonProperty("rain7d")]
        public Rain7d Rain7d { get; set; }

        [JsonProperty("rain48h")]
        public Rain48h Rain48h { get; set; }

        [JsonProperty("rain24h")]
        public Rain24h Rain24h { get; set; }
    }

    public class WeatherInfo
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

        [JsonProperty("config")]
        public Config Config { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("licenses")]
        public bool Licenses { get; set; }

        [Key]
        public Guid Id { get; set; }
    }

    public class Weather
    {
        public List<WeatherInfo> WeatherInfo { get; set; }

        [Key]
        public Guid Id { get; set; }
    }
}