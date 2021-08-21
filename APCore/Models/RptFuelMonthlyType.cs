using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class RptFuelMonthlyType
    {
        public int? Year { get; set; }
        public int? Month { get; set; }
        public string MonthName { get; set; }
        public string AircraftType { get; set; }
        public int? TypeId { get; set; }
        public int? Legs { get; set; }
        public int PreLegs { get; set; }
        public decimal Uplift { get; set; }
        public decimal Used { get; set; }
        public decimal FPFuel { get; set; }
        public decimal PreUsed { get; set; }
        public decimal? UpliftKilo { get; set; }
        public decimal? UsedKilo { get; set; }
        public decimal PreUsedKilo { get; set; }
        public int FlightTime { get; set; }
        public int PreFlightTime { get; set; }
        public int BlockTime { get; set; }
        public int PreBlockTime { get; set; }
        public decimal? UpliftPerLeg { get; set; }
        public decimal? UpliftKiloPerLeg { get; set; }
        public decimal? UsedKiloPerLeg { get; set; }
        public int TotalPax { get; set; }
        public int PreTotalPax { get; set; }
        public int TotalPaxAll { get; set; }
        public int PreTotalPaxAll { get; set; }
        public double Distance { get; set; }
        public double PreDistance { get; set; }
        public double DistanceKM { get; set; }
        public int Weight { get; set; }
        public int PreWeight { get; set; }
        public decimal WeightTone { get; set; }
        public decimal PreWeightTone { get; set; }
        public int PaxWeight { get; set; }
        public decimal PaxWeightTone { get; set; }
        public double WeightDistance { get; set; }
        public double WeightToneDistance { get; set; }
        public decimal? UpliftPerPax { get; set; }
        public decimal? UpliftPerWeight { get; set; }
        public double? UpliftPerDistance { get; set; }
        public double? UpliftPerDistanceKM { get; set; }
        public double? UpliftPerWeightDistance { get; set; }
        public double? UpliftPerWeightDistanceKM { get; set; }
        public decimal? UsedPerPax { get; set; }
        public decimal? UsedPerWeight { get; set; }
        public double? UsedPerDistance { get; set; }
        public double? UsedPerDistanceKM { get; set; }
        public double SeatDistanceKM { get; set; }
        public double SeatKiloDistanceKM { get; set; }
        public double? UsedPerSeatDistanceKM { get; set; }
        public double? UsedPerSeatKiloDistanceKM { get; set; }
        public double PaxDistanceKM { get; set; }
        public double PaxKiloDistanceKM { get; set; }
        public double? UsedPerPaxDistanceKM { get; set; }
        public double PreUsedPerPaxDistanceKM { get; set; }
        public double? UsedPerPaxKiloDistanceKM { get; set; }
        public double PreUsedPerPaxKiloDistanceKM { get; set; }
        public decimal? UsedPerLeg { get; set; }
        public decimal PreUsedPerLeg { get; set; }
        public decimal? UsedPerBlockTime { get; set; }
        public decimal PreUsedPerBlockTime { get; set; }
        public decimal? UsedPerFlightTime { get; set; }
        public decimal PreUsedPerFlightTime { get; set; }
        public double? UsedPerWeightDistance { get; set; }
        public double PreUsedPerWeightDistance { get; set; }
        public double? UsedPerWeightToneDistance { get; set; }
        public double PreUsedPerWeightToneDistance { get; set; }
        public decimal? UsedPerPaxBlockTime { get; set; }
        public decimal PreUsedPerPaxBlockTime { get; set; }
        public decimal? UsedPerWeightToneBlockTime { get; set; }
        public decimal PreUsedPerWeightToneBlockTime { get; set; }
    }
}
