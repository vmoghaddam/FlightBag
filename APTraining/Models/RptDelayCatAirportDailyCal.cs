using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class RptDelayCatAirportDailyCal
    {
        public int? PYear { get; set; }
        public string PMonthName { get; set; }
        public int? PMonth { get; set; }
        public int? PDay { get; set; }
        public string PDayName { get; set; }
        public string PDate { get; set; }
        public string ICategory { get; set; }
        public int? FromAirport { get; set; }
        public string FromAirportIATA { get; set; }
        public int? Delay { get; set; }
        public int PreDelay { get; set; }
        public decimal? DelayPerLeg { get; set; }
        public decimal PreDelayPerLeg { get; set; }
        public decimal? DelayPerLegDiff { get; set; }
        public decimal? DelayPerBL { get; set; }
        public decimal PreDelayPerBL { get; set; }
        public decimal? DelayPerBLDiff { get; set; }
        public int? OnTimeFlightCount { get; set; }
        public int PreOnTimeFlightCount { get; set; }
        public decimal? OnTimeFlightCountDiff { get; set; }
        public decimal? DelayedFlightsPerAll { get; set; }
        public decimal PreDelayedFlightsPerAll { get; set; }
        public decimal? DelayedFlightsPerAllDiff { get; set; }
        public decimal? DelayedFlightsPerOnTime { get; set; }
        public decimal PreDelayedFlightsPerOnTime { get; set; }
        public decimal? DelayedFlightsPerOnTimeDiff { get; set; }
        public int? DelayUnder30 { get; set; }
        public int PreDelayUnder30 { get; set; }
        public decimal? DelayUnder30Diff { get; set; }
        public int? DelayOver30 { get; set; }
        public int PreDelayOver30 { get; set; }
        public decimal? DelayOver30Diff { get; set; }
        public int? Delay3060 { get; set; }
        public int PreDelay3060 { get; set; }
        public decimal? Delay3060Diff { get; set; }
        public int? Delay60120 { get; set; }
        public int PreDelay60120 { get; set; }
        public decimal? Delay60120Diff { get; set; }
        public int? Delay120180 { get; set; }
        public int PreDelay120180 { get; set; }
        public decimal? Delay120180Diff { get; set; }
        public int? DelayOver180 { get; set; }
        public int PreDelayOver180 { get; set; }
        public decimal? DelayOver180Diff { get; set; }
        public int? DelayOver240 { get; set; }
        public int PreDelayOver240 { get; set; }
        public decimal? DelayOver240Diff { get; set; }
        public int? FltDelayUnder30 { get; set; }
        public int PreFltDelayUnder30 { get; set; }
        public decimal? FltDelayUnder30Diff { get; set; }
        public int? FltDelayOver30 { get; set; }
        public int PreFltDelayOver30 { get; set; }
        public decimal? FltDelayOver30Diff { get; set; }
        public int? FltDelay3060 { get; set; }
        public int PreFltDelay3060 { get; set; }
        public decimal? FltDelay3060Diff { get; set; }
        public int? FltDelay60120 { get; set; }
        public int PreFltDelay60120 { get; set; }
        public decimal? FltDelay60120Diff { get; set; }
        public int? FltDelay120180 { get; set; }
        public int PreFltDelay120180 { get; set; }
        public decimal? FltDelay120180Diff { get; set; }
        public int? FltDelayOver180 { get; set; }
        public int PreFltDelayOver180 { get; set; }
        public decimal? FltDelayOver180Diff { get; set; }
        public int? FltDelayOver240 { get; set; }
        public int PreFltDelayOver240 { get; set; }
        public decimal? FltDelayOver240Diff { get; set; }
        public int? FlightCount { get; set; }
        public int PreFlightCount { get; set; }
        public decimal? FlightCountDiff { get; set; }
        public int? AFlightCount { get; set; }
        public int PreAFlightCount { get; set; }
        public decimal? AFlightCountDiff { get; set; }
        public int? BlockTime { get; set; }
        public int PreBlockTime { get; set; }
        public decimal? BlockTimeDiff { get; set; }
        public int? ABlockTime { get; set; }
        public int PreABlockTime { get; set; }
        public decimal? ABlockTimeDiff { get; set; }
        public int? FlightTime { get; set; }
        public int PreFlightTime { get; set; }
        public decimal? FlightTimeDiff { get; set; }
        public int? AFlightTime { get; set; }
        public int PreAFlightTime { get; set; }
        public decimal? AFlightTimeDiff { get; set; }
    }
}
