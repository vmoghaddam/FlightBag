using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFlightFuel
    {
        public int FlightId { get; set; }
        public decimal? UpLift { get; set; }
        public decimal? Remaining { get; set; }
        public decimal? UsedFuel { get; set; }
        public decimal? Taxi { get; set; }
        public decimal? AVGFuelBurned { get; set; }
        public decimal? AVGFuelBurnedReg { get; set; }
        public decimal? AvgVar { get; set; }
        public decimal? AvgVarReg { get; set; }
        public decimal? FPFuel { get; set; }
        public decimal? FPVar { get; set; }
        public int? TotalPax { get; set; }
        public int? FlightH { get; set; }
        public byte? FlightM { get; set; }
        public DateTime? ChocksIn { get; set; }
        public DateTime? Landing { get; set; }
        public DateTime? Takeoff { get; set; }
        public DateTime? ChocksOut { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public DateTime? STDLocal { get; set; }
        public DateTime? STALocal { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? ArrivalLocal { get; set; }
        public DateTime? Date { get; set; }
        public int? FlightStatusID { get; set; }
        public int? RegisterID { get; set; }
        public string FlightNumber { get; set; }
        public int? FromAirport { get; set; }
        public int? ToAirport { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public string RouteIATA { get; set; }
        public int? TypeId { get; set; }
        public string AircraftType { get; set; }
        public string Register { get; set; }
        public string FuelUnit { get; set; }
        public int? FuelUnitID { get; set; }
        public int? TotalSeat { get; set; }
        public DateTime? STDDay { get; set; }
        public DateTime? STADay { get; set; }
        public int CargoWeight { get; set; }
        public string CargoUnit { get; set; }
        public int? BaggageCount { get; set; }
        public int? CargoUnitID { get; set; }
        public int BaggageWeight { get; set; }
        public int? CargoCount { get; set; }
        public int? TotalCargoWeight { get; set; }
        public string Captain { get; set; }
        public string CaptainName { get; set; }
        public int CaptainId { get; set; }
        public int? DurationScheduled { get; set; }
        public int? DurationActual { get; set; }
        public int? FlightTimeFP { get; set; }
        public int? FlightActual { get; set; }
        public string DurationScheduledStr { get; set; }
        public string DurationActualStr { get; set; }
        public string FlightTimeFPStr { get; set; }
        public string FlightActualStr { get; set; }
    }
}
