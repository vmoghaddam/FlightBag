using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFDRReport
    {
        public int Id { get; set; }
        public DateTime? STDDay { get; set; }
        public string FlightNumber { get; set; }
        public string Register { get; set; }
        public int? RegisterID { get; set; }
        public string AircraftType { get; set; }
        public int? TypeId { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STDLocal { get; set; }
        public DateTime? STA { get; set; }
        public DateTime? STALocal { get; set; }
        public DateTime? Takeoff { get; set; }
        public DateTime? Landing { get; set; }
        public DateTime? TakeoffLocal { get; set; }
        public DateTime? LandingLocal { get; set; }
        public string IP { get; set; }
        public string IPSCH { get; set; }
        public string IPCode { get; set; }
        public int? IPId { get; set; }
        public string P1 { get; set; }
        public string P1SCH { get; set; }
        public string P1Code { get; set; }
        public int? P1Id { get; set; }
        public string P2 { get; set; }
        public string P2SCH { get; set; }
        public string P2Code { get; set; }
        public int? P2Id { get; set; }
        public string FlightStatus { get; set; }
        public int? FlightStatusID { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public int? FromAirport { get; set; }
        public int? ToAirport { get; set; }
        public decimal? FuelRemaining { get; set; }
        public decimal? FuelUplift { get; set; }
        public decimal? FuelUsed { get; set; }
        public int? FuelUnitID { get; set; }
        public string FuelUnit { get; set; }
        public int? PFLR { get; set; }
        public decimal? FPFuel { get; set; }
        public string PFLRTitle { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? ArrivalLocal { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public int? BlockTime { get; set; }
        public int? FlightTime { get; set; }
        public int? Freight { get; set; }
    }
}
