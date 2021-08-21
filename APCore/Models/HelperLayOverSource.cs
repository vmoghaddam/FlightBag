using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class HelperLayOverSource
    {
        public int? CrewId { get; set; }
        public string FlightNumber { get; set; }
        public DateTime? STDDayLocal { get; set; }
        public DateTime? STADayLocal { get; set; }
        public DateTime? STALocal { get; set; }
        public string ToAirportIATA { get; set; }
        public int? ToAirport { get; set; }
    }
}
