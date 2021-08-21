using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class AppLegJLHelper
    {
        public int ID { get; set; }
        public string FlightNumber { get; set; }
        public int? FromAirport { get; set; }
        public int? ToAirport { get; set; }
        public int? CustomerId { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public string Register { get; set; }
        public DateTime? STDDay { get; set; }
        public DateTime? STDDayLocal { get; set; }
        public string PIC { get; set; }
        public int? PICId { get; set; }
    }
}
