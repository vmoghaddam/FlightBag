using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class WeatherForecastIcingCondition
    {
        public int Id { get; set; }
        public int forecast_id { get; set; }
        public string icing_intensity { get; set; }
        public double? icing_min_alt_ft_agl { get; set; }
        public double? icing_max_alt_ft_agl { get; set; }

        public virtual WeatherTafForecast forecast { get; set; }
    }
}
