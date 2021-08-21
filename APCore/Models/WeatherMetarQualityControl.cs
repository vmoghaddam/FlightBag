using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class WeatherMetarQualityControl
    {
        public int Id { get; set; }
        public int MetarId { get; set; }
        public string corrected { get; set; }
        public string auto { get; set; }
        public string auto_station { get; set; }
        public string maintenance_indicator_on { get; set; }
        public string no_signal { get; set; }
        public string lightning_sensor_off { get; set; }
        public string freezing_rain_sensor_off { get; set; }
        public string present_weather_sensor_off { get; set; }

        public virtual WeatherMetar Metar { get; set; }
    }
}
