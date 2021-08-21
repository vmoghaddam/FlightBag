using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class WeatherForecastSkyCondition
    {
        public int Id { get; set; }
        public int forecast_id { get; set; }
        public string sky_cover { get; set; }
        public double? cloud_base_ft_agl { get; set; }
        public string cloud_type { get; set; }

        public virtual WeatherTafForecast forecast { get; set; }
    }
}
