using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class SunTime
    {
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime Date { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public int? AirportId { get; set; }
        public int? TOffset { get; set; }
        public DateTime? Sunrise { get; set; }
        public DateTime? Sunset { get; set; }
        public DateTime? SolarNoon { get; set; }
        public int? DayLength { get; set; }
        public DateTime? CivilTwilightBegin { get; set; }
        public DateTime? CivilTwilightEnd { get; set; }
        public DateTime? NauticalTwilightBegin { get; set; }
        public DateTime? NauticalTwilightEnd { get; set; }
        public DateTime? AstronomicalTwilightBegin { get; set; }
        public DateTime? AstronomicalTwilightEnd { get; set; }
    }
}
