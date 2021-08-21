using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class HelperCurrentLocation
    {
        public int FDPItemId { get; set; }
        public int FDPId { get; set; }
        public int FlightId { get; set; }
        public int? CrewId { get; set; }
        public int? FromAirport { get; set; }
        public int? ToAirport { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public int? FlightStatusID { get; set; }
        public long? Rank { get; set; }
    }
}
