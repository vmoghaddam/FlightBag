using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFlightCockpit
    {
        public int ID { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? STDLocal { get; set; }
        public DateTime? STALocal { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? ArrivalLocal { get; set; }
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
        public int PaxAdult { get; set; }
        public int PaxChild { get; set; }
        public int PaxInfant { get; set; }
        public int? TotalPax { get; set; }
        public decimal? FuelDeparture { get; set; }
        public int? CargoCount { get; set; }
        public int CargoWeight { get; set; }
        public int BaggageWeight { get; set; }
        public int? BaggageCount { get; set; }
        public DateTime? STDDay { get; set; }
        public string PDate { get; set; }
        public int? FlightTime { get; set; }
        public int? FlightTimeActual { get; set; }
        public int? SITATime { get; set; }
        public int? BlockTime { get; set; }
        public double? ActualFlightTimeToSITA { get; set; }
        public string IP { get; set; }
        public string Captain { get; set; }
        public string IPName { get; set; }
        public string CaptainName { get; set; }
        public int IPId { get; set; }
        public int CaptainId { get; set; }
        public int FlightStatusID { get; set; }
        public string FlightStatus { get; set; }
        public DateTime? JLOffBlock { get; set; }
        public DateTime? JLOnBlock { get; set; }
        public DateTime? JLTakeOff { get; set; }
        public DateTime? JLLanding { get; set; }
        public int? PFLR { get; set; }
        public int? JLBlockTime { get; set; }
        public int? JLFlightTime { get; set; }
    }
}
