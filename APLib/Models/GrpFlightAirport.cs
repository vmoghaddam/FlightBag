﻿using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class GrpFlightAirport
    {
        public int PYear { get; set; }
        public string PMonthName { get; set; }
        public int Pmonth { get; set; }
        public int? FromAirport { get; set; }
        public string FromAirportIATA { get; set; }
        public int? FlightCount { get; set; }
        public int? BlockTime { get; set; }
        public int? FlightTime { get; set; }
        public int? TotalPax { get; set; }
        public int? TotalPaxAll { get; set; }
    }
}
