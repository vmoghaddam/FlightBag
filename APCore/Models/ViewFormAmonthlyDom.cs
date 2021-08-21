using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFormAMonthlyDom
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string YearName { get; set; }
        public string MonthName { get; set; }
        public string YearMonth { get; set; }
        public int? Legs { get; set; }
        public decimal? FlightHour { get; set; }
        public int? PaxChild { get; set; }
        public int? PaxInfant { get; set; }
        public int? PaxAdult { get; set; }
        public int? PaxTotal { get; set; }
        public double? PaxTotalDistRound { get; set; }
        public double? PaxTotalDist { get; set; }
        public int? PaxAll { get; set; }
        public int? TotalSeat { get; set; }
        public double? TotalSeatDist { get; set; }
        public int? PaxLoad { get; set; }
        public double? TotalSeatDistRound { get; set; }
        public int? PaxAllWeight { get; set; }
        public double? PaxAllWeightDistance { get; set; }
        public int? BaggageWeight { get; set; }
        public int? CargoWeight { get; set; }
        public int? Freight { get; set; }
        public decimal? FreightTone { get; set; }
        public double? FreightToneDistance { get; set; }
        public double? TotalToneDistance { get; set; }
        public double? TotalToneDistanceAvailable { get; set; }
        public double? WeightLoadFactor { get; set; }
        public double? Distance { get; set; }
    }
}
