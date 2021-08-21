using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class AvgFlight
    {
        public int FromAirport { get; set; }
        public int ToAirport { get; set; }
        public decimal? Duration { get; set; }
        public decimal? FlightH { get; set; }
        public decimal? FlightM { get; set; }
    }
}
