using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class WeatherForecastTemperature
    {
        public int Id { get; set; }
        public int forecast_id { get; set; }
        public DateTime? valid_time { get; set; }
        public double? sfc_temp_c { get; set; }
        public string max_temp_c { get; set; }
        public string min_temp_c { get; set; }

        public virtual WeatherTafForecast forecast { get; set; }
    }
}
