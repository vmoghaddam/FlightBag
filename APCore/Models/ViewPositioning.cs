using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewPositioning
    {
        public int Id { get; set; }
        public int FDPId { get; set; }
        public int? CrewId { get; set; }
        public int? FlightId { get; set; }
        public string FlightNumber { get; set; }
        public DateTime? STDDay { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? ArrivalLocal { get; set; }
    }
}
