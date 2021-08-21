using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class WeatherTafForecast
    {
        public WeatherTafForecast()
        {
            WeatherForecastIcingConditions = new HashSet<WeatherForecastIcingCondition>();
            WeatherForecastSkyConditions = new HashSet<WeatherForecastSkyCondition>();
            WeatherForecastTemperatures = new HashSet<WeatherForecastTemperature>();
            WeatherForecastTurbulences = new HashSet<WeatherForecastTurbulence>();
        }

        public int Id { get; set; }
        public DateTime? fcst_time_from { get; set; }
        public DateTime? fcst_time_to { get; set; }
        public string change_indicator { get; set; }
        public DateTime? time_becoming { get; set; }
        public double? probability { get; set; }
        public double? wind_dir_degrees { get; set; }
        public double? wind_speed_kt { get; set; }
        public double? wind_gust_kt { get; set; }
        public double? wind_shear_hgt_ft_agl { get; set; }
        public double? wind_shear_dir_degrees { get; set; }
        public double? wind_shear_speed_kt { get; set; }
        public double? visibility_statute_mi { get; set; }
        public double? altim_in_hg { get; set; }
        public double? vert_vis_ft { get; set; }
        public string wx_string { get; set; }
        public string not_decoded { get; set; }
        public int weather_id { get; set; }

        public virtual WeatherTaf weather { get; set; }
        public virtual ICollection<WeatherForecastIcingCondition> WeatherForecastIcingConditions { get; set; }
        public virtual ICollection<WeatherForecastSkyCondition> WeatherForecastSkyConditions { get; set; }
        public virtual ICollection<WeatherForecastTemperature> WeatherForecastTemperatures { get; set; }
        public virtual ICollection<WeatherForecastTurbulence> WeatherForecastTurbulences { get; set; }
    }
}
