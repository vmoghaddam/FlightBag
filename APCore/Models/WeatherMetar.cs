using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class WeatherMetar
    {
        public WeatherMetar()
        {
            WeatherMetarQualityControls = new HashSet<WeatherMetarQualityControl>();
            WeatherMetarSkyConditions = new HashSet<WeatherMetarSkyCondition>();
        }

        public int Id { get; set; }
        public DateTime? DateCreate { get; set; }
        public string StationId { get; set; }
        public string RawText { get; set; }
        public DateTime? observation_time { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
        public double? temp_c { get; set; }
        public double? dewpoint_c { get; set; }
        public int? wind_dir_degrees { get; set; }
        public int? wind_speed_kt { get; set; }
        public int? wind_gust_kt { get; set; }
        public double? visibility_statute_mi { get; set; }
        public double? altim_in_hg { get; set; }
        public double? sea_level_pressure_mb { get; set; }
        public string flight_category { get; set; }
        public double? three_hr_pressure_tendency_mb { get; set; }
        public double? maxT_c { get; set; }
        public double? minT_c { get; set; }
        public double? maxT24hr_c { get; set; }
        public double? minT24hr_c { get; set; }
        public double? precip_in { get; set; }
        public double? pcp3hr_in { get; set; }
        public double? pcp6hr_in { get; set; }
        public double? pcp24hr_in { get; set; }
        public double? snow_in { get; set; }
        public int? vert_vis_ft { get; set; }
        public string metar_type { get; set; }
        public double? elevation_m { get; set; }
        public DateTime? DateDay { get; set; }
        public int? FlightId { get; set; }
        public int? FDPId { get; set; }

        public virtual ICollection<WeatherMetarQualityControl> WeatherMetarQualityControls { get; set; }
        public virtual ICollection<WeatherMetarSkyCondition> WeatherMetarSkyConditions { get; set; }
    }
}
