using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class HelperLayOver
    {
        public int? CrewId { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
        public string FlightNumber { get; set; }
        public DateTime? STDDayLocal { get; set; }
        public DateTime? STADayLocal { get; set; }
        public DateTime? STALocal { get; set; }
        public string ToAirportIATA { get; set; }
        public int? ToAirport { get; set; }
        public int? BaseAirportId { get; set; }
        public long? DateRank { get; set; }
    }
}
