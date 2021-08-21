using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewLayOver
    {
        public int Id { get; set; }
        public int? FlightId { get; set; }
        public DateTime? STDDay { get; set; }
        public string FlightNumber { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public int? FromAirport { get; set; }
        public int? ToAirport { get; set; }
        public int? CrewId { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
        public int? BaseAirportId { get; set; }
        public int IsLayOver { get; set; }
    }
}
