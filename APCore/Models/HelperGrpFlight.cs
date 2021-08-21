using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class HelperGrpFlight
    {
        public int PYear { get; set; }
        public string PMonthName { get; set; }
        public int Pmonth { get; set; }
        public int? FlightCount { get; set; }
        public int PreFlightCount { get; set; }
        public int? BlockTime { get; set; }
        public int PreBlockTime { get; set; }
        public int? FlightTime { get; set; }
        public int PreFlightTime { get; set; }
        public int? TotalPax { get; set; }
        public int PreTotalPax { get; set; }
        public int? TotalPaxAll { get; set; }
        public int PreTotalPaxAll { get; set; }
    }
}
