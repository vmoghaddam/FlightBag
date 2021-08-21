using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class RptFuelLeg
    {
        public int ID { get; set; }
        public DateTime? LocalDate { get; set; }
        public string PDate { get; set; }
        public string PYearName { get; set; }
        public int? PYear { get; set; }
        public string PMonthName { get; set; }
        public int? PMonth { get; set; }
        public int Season { get; set; }
        public string SeasonTitle { get; set; }
        public string PDayName { get; set; }
        public int? PDay { get; set; }
        public string PYearMonthName { get; set; }
        public int FlightId { get; set; }
        public DateTime? Date { get; set; }
        public int? FlightStatusID { get; set; }
        public int? RegisterID { get; set; }
        public string AircraftType { get; set; }
        public int? TypeId { get; set; }
        public string FlightNumber { get; set; }
        public int? FromAirport { get; set; }
        public int? ToAirport { get; set; }
        public DateTime? ChocksIn { get; set; }
        public DateTime? Landing { get; set; }
        public DateTime? Takeoff { get; set; }
        public DateTime? ChocksOut { get; set; }
        public int? CustomerId { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public string Register { get; set; }
        public decimal? Defuel { get; set; }
        public decimal? FPFuel { get; set; }
        public decimal? FPFuelKilo { get; set; }
        public int? TotalPax { get; set; }
        public decimal? TotalPaxKilo { get; set; }
        public int? FuelUnitID { get; set; }
        public string FuelUnit { get; set; }
        public int? CargoUnitID { get; set; }
        public string CargoUnit { get; set; }
        public int? CargoCount { get; set; }
        public int? BaggageCount { get; set; }
        public DateTime? STDLocal { get; set; }
        public DateTime? STALocal { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public string FlightStatus { get; set; }
        public DateTime? STDDay { get; set; }
        public DateTime? STADay { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? ArrivalLocal { get; set; }
        public DateTime? TakeoffLocal { get; set; }
        public DateTime? LandingLocal { get; set; }
        public int? BlockTime { get; set; }
        public int? FlightTime { get; set; }
        public int? SITATime { get; set; }
        public int? PaxChild { get; set; }
        public int? PaxInfant { get; set; }
        public int? PaxAdult { get; set; }
        public decimal? Remaining { get; set; }
        public decimal? UpLift { get; set; }
        public decimal? UpliftKilo { get; set; }
        public decimal? Used { get; set; }
        public decimal? UsedKilo { get; set; }
        public int? TotalSeat { get; set; }
        public int BaggageWeight { get; set; }
        public int CargoWeight { get; set; }
        public int? Freight { get; set; }
        public decimal? FreightTone { get; set; }
        public int? TotalPaxAll { get; set; }
        public decimal? TotalPaxAllKilo { get; set; }
        public int? Weight { get; set; }
        public decimal? WeightTone { get; set; }
        public int? PaxWeight { get; set; }
        public decimal? PaxWeightTone { get; set; }
        public string Route { get; set; }
        public double? DistanceKM { get; set; }
        public double? Distance { get; set; }
        public double? PaxDistanceKM { get; set; }
        public double? PaxKiloDistanceKM { get; set; }
        public double? SeatDistanceKM { get; set; }
        public double? SeatKiloDistanceKM { get; set; }
        public double? WeightDistance { get; set; }
        public double? WeightToneDistance { get; set; }
        public double? WeightDistanceToneKM { get; set; }
        public decimal? PaxBlockTime { get; set; }
        public decimal? WeightBlockTime { get; set; }
        public decimal? WeightToneBlockTime { get; set; }
        public decimal? UsedPerSeatBlockTime { get; set; }
        public decimal? SeatBlockTime { get; set; }
        public double? UsedPerPaxKiloDistanceKM { get; set; }
        public double? UsedPerSeatKiloDistanceKM { get; set; }
        public decimal? UsedPerPaxBlockTime { get; set; }
        public decimal? UsedPerWeightToneBlockTime { get; set; }
        public double? UsedPerWeightToneDistance { get; set; }
        public decimal? UsedPerBlockTime { get; set; }
        public decimal? UsedPerPax { get; set; }
        public decimal UsedPerLeg { get; set; }
        public decimal? UsedPerUpLift { get; set; }
        public decimal? UsedPerFPFuel { get; set; }
    }
}
