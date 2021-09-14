using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class HelperDelayDaily
    {
        public int? PYear { get; set; }
        public string PMonthName { get; set; }
        public int? PMonth { get; set; }
        public int? PDay { get; set; }
        public string PDate { get; set; }
        public int Delay { get; set; }
        public decimal? DelayPerLeg { get; set; }
        public decimal? DelayPerBL { get; set; }
        public int? OnTimeFlightCount { get; set; }
        public decimal? DelayedFlightsPerAll { get; set; }
        public decimal? OnTimeFlightsPerAll { get; set; }
        public decimal? DelayedFlightsPerOnTime { get; set; }
        public decimal? DelayedPaxPerAll { get; set; }
        public int PaxDelay120180 { get; set; }
        public int PaxDelayOver180 { get; set; }
        public int PaxDelayOver240 { get; set; }
        public int DelayUnder30 { get; set; }
        public int DelayOver30 { get; set; }
        public int Delay3060 { get; set; }
        public int Delay60120 { get; set; }
        public int Delay120180 { get; set; }
        public int DelayOver180 { get; set; }
        public int DelayOver240 { get; set; }
        public int DelayUnder30Time { get; set; }
        public int DelayOver30Time { get; set; }
        public int Delay3060Time { get; set; }
        public int Delay60120Time { get; set; }
        public int Delay120180Time { get; set; }
        public int DelayOver180Time { get; set; }
        public int DelayOver240Time { get; set; }
        public int FltDelayUnder30 { get; set; }
        public decimal? FltDelayUnder30PerAll { get; set; }
        public decimal? FltDelayUnder30PerDelayed { get; set; }
        public int FltDelayOver30 { get; set; }
        public decimal? FltDelayOver30PerAll { get; set; }
        public decimal? FltDelayOver30PerDelayed { get; set; }
        public int FltDelay3060 { get; set; }
        public decimal? FltDelay3060PerAll { get; set; }
        public decimal? FltDelay3060PerDelayed { get; set; }
        public int FltDelay60120 { get; set; }
        public decimal? FltDelay60120PerAll { get; set; }
        public decimal? FltDelay60120PerDelayed { get; set; }
        public int FltDelay120180 { get; set; }
        public decimal? FltDelay120180PerAll { get; set; }
        public decimal? FltDelay120180PerDelayed { get; set; }
        public int FltDelayOver180 { get; set; }
        public decimal? FltDelayOver180PerAll { get; set; }
        public decimal? FltDelayOver180PerDelayed { get; set; }
        public int FltDelayOver240 { get; set; }
        public decimal? FltDelayOver240PerAll { get; set; }
        public decimal? FltDelayOver240PerDelayed { get; set; }
        public int PaxDelayOver30 { get; set; }
        public int PaxDelay3060 { get; set; }
        public int PaxDelay60120 { get; set; }
        public int FlightCount { get; set; }
        public int? AFlightCount { get; set; }
        public int BlockTime { get; set; }
        public int? ABlockTime { get; set; }
        public int FlightTime { get; set; }
        public int? AFlightTime { get; set; }
        public int TotalPax { get; set; }
        public int? ATotalPax { get; set; }
        public int TotalPaxAll { get; set; }
        public int? ATotalPaxAll { get; set; }
    }
}
