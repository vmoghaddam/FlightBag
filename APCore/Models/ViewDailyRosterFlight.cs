using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewDailyRosterFlight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? ArrivalLocal { get; set; }
        public int? FromAirport { get; set; }
        public string FromAirportIATA { get; set; }
        public int? ToAirport { get; set; }
        public string ToAirportIATA { get; set; }
        public string Register { get; set; }
        public int? CrewId { get; set; }
        public bool? IsPositioning { get; set; }
        public DateTime? DepartureDate { get; set; }
    }
}
