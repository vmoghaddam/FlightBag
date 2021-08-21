using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class PLUPD
    {
        public DateTime? STDDay { get; set; }
        public string DayName { get; set; }
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public int? FromAirport { get; set; }
        public int? ToAirport { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public DateTime? NewSTD { get; set; }
        public DateTime? NewSTA { get; set; }
        public DateTime? NSTD { get; set; }
        public DateTime? NSTA { get; set; }
    }
}
