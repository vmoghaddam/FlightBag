using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class WeatherForecastTurbulence
    {
        public int Id { get; set; }
        public string turbulence_intensity { get; set; }
        public double? turbulence_min_alt_ft_agl { get; set; }
        public double? turbulence_max_alt_ft_agl { get; set; }
        public int forecast_id { get; set; }

        public virtual WeatherTafForecast forecast { get; set; }
    }
}
