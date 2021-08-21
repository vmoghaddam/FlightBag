using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class RptFlight
    {
        public string PDate { get; set; }
        public int? PYear { get; set; }
        public string PMonthName { get; set; }
        public int? PMonth { get; set; }
        public string PDayName { get; set; }
        public int? PDay { get; set; }
        public int ID { get; set; }
        public int FlightId { get; set; }
        public int? RegisterID { get; set; }
        public int? FlightStatusID { get; set; }
        public string AircraftType { get; set; }
        public int? TypeId { get; set; }
        public string FlightNumber { get; set; }
        public int? FromAirport { get; set; }
        public int? ToAirport { get; set; }
        public int? CustomerId { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public string Register { get; set; }
        public string FlightStatus { get; set; }
        public DateTime? STDDay { get; set; }
        public DateTime? STADay { get; set; }
        public int? BlockTime { get; set; }
        public int? PaxAdult { get; set; }
        public int? PaxInfant { get; set; }
        public int? PaxChild { get; set; }
        public int? FlightTime { get; set; }
        public int? TotalPax { get; set; }
        public int? TotalPaxAll { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public DateTime? STDLocal { get; set; }
        public DateTime? STALocal { get; set; }
    }
}
