using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class GrpFlightReg
    {
        public int PYear { get; set; }
        public string PMonthName { get; set; }
        public int Pmonth { get; set; }
        public int? TypeId { get; set; }
        public string AircraftType { get; set; }
        public int? RegisterID { get; set; }
        public string Register { get; set; }
        public int? FlightCount { get; set; }
        public int? BlockTime { get; set; }
        public int? FlightTime { get; set; }
        public int? TotalPax { get; set; }
        public int? TotalPaxAll { get; set; }
    }
}
