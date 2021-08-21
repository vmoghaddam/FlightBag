using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewRegHistory2
    {
        public int Id { get; set; }
        public DateTime? STDDay { get; set; }
        public string FlightNumber { get; set; }
        public string Register { get; set; }
        public int? RegisterID { get; set; }
        public string AircraftType { get; set; }
        public string Fleet { get; set; }
        public int? TypeId { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STDLocal { get; set; }
        public DateTime? STA { get; set; }
        public DateTime? STALocal { get; set; }
        public DateTime? Takeoff { get; set; }
        public DateTime? Landing { get; set; }
        public DateTime? TakeoffLocal { get; set; }
        public DateTime? LandingLocal { get; set; }
        public DateTime? OffBlockLocal { get; set; }
        public DateTime? OnBlockLocal { get; set; }
        public string FlightStatus { get; set; }
        public int FlightStatusID { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public string Route { get; set; }
        public int? FromAirport { get; set; }
        public int? ToAirport { get; set; }
        public int PaxChild { get; set; }
        public int PaxInfant { get; set; }
        public int PaxAdult { get; set; }
        public int? PaxTotal { get; set; }
        public int? PaxTotalAll { get; set; }
        public int? Delay { get; set; }
        public int? FuelUnitID { get; set; }
        public decimal? RemainingFuel { get; set; }
        public decimal? UpliftFuel { get; set; }
        public decimal? UsedFuel { get; set; }
        public int? FlightTimeActual { get; set; }
        public int? BlockTime { get; set; }
        public int TotalSeat { get; set; }
        public int BaggageWeight { get; set; }
        public int CargoWeight { get; set; }
        public int? Freight { get; set; }
        public string PDate { get; set; }
        public string PYearName { get; set; }
        public int? PYear { get; set; }
        public string PMonthName { get; set; }
        public int? PMonth { get; set; }
        public string PDayName { get; set; }
        public string PYearMonthName { get; set; }
    }
}
