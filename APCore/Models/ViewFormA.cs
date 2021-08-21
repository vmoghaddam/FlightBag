using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFormA
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
        public decimal? FlightHour { get; set; }
        public int? FlightMinutes { get; set; }
        public string FlightStatus { get; set; }
        public int? FlightStatusID { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public string Route { get; set; }
        public int? FromAirport { get; set; }
        public int? ToAirport { get; set; }
        public int PaxChild { get; set; }
        public int PaxInfant { get; set; }
        public int PaxAdult { get; set; }
        public int? PaxTotal { get; set; }
        public double? PaxTotalDistRound { get; set; }
        public double? PaxTotalDist { get; set; }
        public int? PaxAll { get; set; }
        public int TotalSeat { get; set; }
        public double? TotalSeatDist { get; set; }
        public int? PaxLoad { get; set; }
        public double? TotalSeatDistRound { get; set; }
        public int? PaxAllWeight { get; set; }
        public double? PaxAllWeightDistance { get; set; }
        public string DayName { get; set; }
        public string YearName { get; set; }
        public int? Year { get; set; }
        public string MonthName { get; set; }
        public int? Month { get; set; }
        public string YearMonthName { get; set; }
        public string PDate { get; set; }
        public string PYearName { get; set; }
        public int? PYear { get; set; }
        public string PMonthName { get; set; }
        public int? PMonth { get; set; }
        public string PDayName { get; set; }
        public string PYearMonthName { get; set; }
        public int? Quarter { get; set; }
        public int BaggageWeight { get; set; }
        public int CargoWeight { get; set; }
        public int? Freight { get; set; }
        public decimal? FreightTone { get; set; }
        public double? FreightToneDistance { get; set; }
        public double? Mail { get; set; }
        public double? TotalToneDistance { get; set; }
        public double? TotalToneDistanceAvailable { get; set; }
        public double? WeightLoadFactor { get; set; }
        public double? Distance { get; set; }
        public int IsDom { get; set; }
    }
}
