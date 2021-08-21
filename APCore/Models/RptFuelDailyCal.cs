using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class RptFuelDailyCal
    {
        public string Date { get; set; }
        public string ArgStr { get; set; }
        public int? ArgNum { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public string MonthName { get; set; }
        public string DayName { get; set; }
        public int? Day { get; set; }
        public int? Legs { get; set; }
        public decimal? Uplift { get; set; }
        public decimal? Used { get; set; }
        public decimal? PreUsed { get; set; }
        public int FlightTime { get; set; }
        public int BlockTime { get; set; }
        public decimal? UsedPerBlockTime { get; set; }
        public decimal? UpliftKilo { get; set; }
        public decimal? UsedKilo { get; set; }
        public decimal? UpliftPerLeg { get; set; }
        public decimal? UsedPerLeg { get; set; }
        public decimal? UpliftKiloPerLeg { get; set; }
        public decimal? UsedKiloPerLeg { get; set; }
        public double? TotalPax { get; set; }
        public double? TotalPaxAll { get; set; }
        public double? Distance { get; set; }
        public double? DistanceKM { get; set; }
        public double? Weight { get; set; }
        public double? WeightTone { get; set; }
        public double? PaxWeight { get; set; }
        public double? PaxWeightTone { get; set; }
        public double? WeightDistance { get; set; }
        public double? WeightDistanceToneKM { get; set; }
        public decimal? UpliftPerPax { get; set; }
        public DateTime? LocalDate { get; set; }
        public decimal? UpliftPerWeight { get; set; }
        public double? UpliftPerDistance { get; set; }
        public double? UpliftPerDistanceKM { get; set; }
        public double? UpliftPerWeightDistance { get; set; }
        public double? UpliftPerWeightDistanceKM { get; set; }
        public decimal? UsedPerPax { get; set; }
        public decimal? UsedPerWeight { get; set; }
        public double? UsedPerDistance { get; set; }
        public double? UsedPerDistanceKM { get; set; }
        public double? UsedPerWeightDistance { get; set; }
        public double? UsedPerWeightDistanceKM { get; set; }
        public decimal? UsedDiff { get; set; }
        public decimal? UsedDiffPerLeg { get; set; }
        public decimal? UsedDiffPerPax { get; set; }
        public decimal? UsedDiffPerWeight { get; set; }
        public double? UsedDiffPerDistance { get; set; }
        public double? UsedDiffPerWeightDistance { get; set; }
        public decimal? UsedDiffPercent { get; set; }
        public decimal? UsedDiffPerLegPercent { get; set; }
        public decimal? UsedDiffPerPaxPercent { get; set; }
        public decimal? UsedDiffPerWeightPercent { get; set; }
        public double? UsedDiffPerDistancePercent { get; set; }
        public double? UsedDiffPerWeightDistancePercent { get; set; }
        public double? UsedPerWeightDistanceToneKM { get; set; }
        public double? UsedPerPaxKiloDistanceKM { get; set; }
        public double? UsedPerSeatKiloDistanceKM { get; set; }
        public decimal? UsedPerWeightToneBlockTime { get; set; }
        public decimal? UsedPerUpLift { get; set; }
        public decimal? UsedPerFPFuel { get; set; }
        public decimal? UsedPerPaxBlockTime { get; set; }
    }
}
