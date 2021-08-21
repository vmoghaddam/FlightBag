using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class _WeatherTafADDX
    {
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public string StationId { get; set; }
        public string RawText { get; set; }
        public DateTime? IssueTime { get; set; }
        public DateTime? BulletinTime { get; set; }
        public DateTime? ValidTimeFrom { get; set; }
        public DateTime? ValidTimeTo { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? EvaluationM { get; set; }
        public string Remarks { get; set; }
    }

    public partial class _WeatherTafADDForecast
    {
        public DateTime? fcst_time_from { get; set; }
        public DateTime? fcst_time_to { get; set; }
        public string change_indicator { get; set; }
        public DateTime? time_becoming { get; set; }
        public decimal probability { get; set; }
        public decimal wind_dir_degrees { get; set; }
        public decimal wind_speed_kt { get; set; }
        public decimal wind_gust_kt { get; set; }
        public decimal wind_shear_hgt_ft_agl { get; set; }
        public decimal wind_shear_dir_degrees { get; set; }
        public decimal wind_shear_speed_kt { get; set; }
        public decimal visibility_statute_mi { get; set; }
        public decimal altim_in_hg { get; set; }
        public decimal vert_vis_ft { get; set; }
        public string wx_string { get; set; }
        public string not_decoded { get; set; }
        public List<sky_condition> sky_conditions { get; set; }
        public List<temperature> temperatures { get; set; }
        public List<turbulence_condition> turbulence_conditions { get; set; }

    }

    public partial class sky_condition
    {
        public string sky_cover { get; set; }
        public decimal cloud_base_ft_agl { get; set; }
        public string cloud_type { get; set; }
    }

    public partial class turbulence_condition
    {
        public string turbulence_intensity { get; set; }
        public decimal turbulence_min_alt_ft_agl { get; set; }
        public decimal turbulence_max_alt_ft_agl { get; set; }
    }

    public partial class temperature
    {

        public DateTime? valid_time { get; set; }
        public decimal sfc_temp_c { get; set; }
        public string max_temp_c { get; set; }
        public string min_temp_c { get; set; }
    }
    public partial class icing_condition
    {
        public string icing_intensity { get; set; }
        public decimal icing_min_alt_ft_agl { get; set; }
        public decimal icing_max_alt_ft_agl { get; set; }
    }

}
