﻿using System.Collections.Generic;

namespace WeatherForecast.Models
{
    public class Device
    {
        public Device()
        {
            DeviceInformation = new List<DeviceInfo>();
        }

        public List<DeviceInfo> DeviceInformation { get; set; }
        public bool HasNoData { get; set; }
    }

    public class DeviceInfo
    {
        public int DeviceID { get; set; }
        public string DeviceName { get; set; }
        public double Firmware { get; set; }
        public double Hardware { get; set; }
        public Rain7Dayinfo Rain7DayInfo { get; set; }
    }

    public class Rain7Dayinfo
    {
        public Rain7Dayinfo()
        {
            Vals = new List<double>();
        }

        public double Sum { get; set; }
        public List<double> Vals { get; set; }
    }
}