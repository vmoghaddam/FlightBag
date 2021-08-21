using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class WeatherMetarSkyCondition
    {
        public int Id { get; set; }
        public int MetarId { get; set; }
        public string sky_cover { get; set; }
        public int? cloud_base_ft_agl { get; set; }

        public virtual WeatherMetar Metar { get; set; }
    }
}
