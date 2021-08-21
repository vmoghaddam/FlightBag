using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFlightSecurityDH
    {
        public int ID { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public int? RegisterID { get; set; }
        public int? FlightTypeID { get; set; }
        public string FlightType { get; set; }
        public int? TypeId { get; set; }
        public string FlightNumber { get; set; }
        public int? FromAirport { get; set; }
        public int? ToAirport { get; set; }
        public int? CustomerId { get; set; }
        public string Customer { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public string Register { get; set; }
        public string AircraftType { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? ArrivalLocal { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? STDDay { get; set; }
        public string CPT { get; set; }
        public string CPT2 { get; set; }
        public string OBSP1 { get; set; }
        public string IP { get; set; }
        public string IP2 { get; set; }
        public string Safety { get; set; }
        public string FO { get; set; }
        public string FO2 { get; set; }
        public string OBSP2 { get; set; }
        public string ISCCM { get; set; }
        public string Purser { get; set; }
        public string Purser2 { get; set; }
        public string Purser3 { get; set; }
        public string FA1 { get; set; }
        public string FA2 { get; set; }
        public string FA3 { get; set; }
        public string FA4 { get; set; }
        public string CAOBS1 { get; set; }
        public string CAOBS2 { get; set; }
        public string CAOBS3 { get; set; }
        public string CAOBS4 { get; set; }
        public string CACheck1 { get; set; }
        public string CACheck2 { get; set; }
        public string CACheck3 { get; set; }
        public string CACheck4 { get; set; }
    }
}
