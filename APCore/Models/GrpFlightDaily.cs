using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class GrpFlightDaily
    {
        public int? PYear { get; set; }
        public string PMonthName { get; set; }
        public int? PMonth { get; set; }
        public string PDate { get; set; }
        public int? PDay { get; set; }
        public int? FlightCount { get; set; }
        public int? BlockTime { get; set; }
        public int? FlightTime { get; set; }
        public int? TotalPax { get; set; }
        public int? TotalPaxAll { get; set; }
    }
}
