﻿using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class RptDelayDaily
    {
        public int? PYear { get; set; }
        public string PMonthName { get; set; }
        public int? PMonth { get; set; }
        public int? PDay { get; set; }
        public string PDate { get; set; }
        public int? Delay { get; set; }
        public int PreDelay { get; set; }
        public decimal? DelayPerLeg { get; set; }
        public decimal PreDelayPerLeg { get; set; }
        public decimal? DelayPerBL { get; set; }
        public decimal PreDelayPerBL { get; set; }
        public int? OnTimeFlightCount { get; set; }
        public int PreOnTimeFlightCount { get; set; }
        public decimal? DelayedFlightsPerAll { get; set; }
        public decimal PreDelayedFlightsPerAll { get; set; }
        public decimal? DelayedFlightsPerOnTime { get; set; }
        public decimal PreDelayedFlightsPerOnTime { get; set; }
        public decimal? DelayedPaxPerAll { get; set; }
        public decimal PreDelayedPaxPerAll { get; set; }
        public int? PaxDelay120180 { get; set; }
        public int PrePaxDelay120180 { get; set; }
        public int? PaxDelayOver180 { get; set; }
        public int PrePaxDelayOver180 { get; set; }
        public int? PaxDelayOver240 { get; set; }
        public int PrePaxDelayOver240 { get; set; }
        public int? DelayUnder30 { get; set; }
        public int PreDelayUnder30 { get; set; }
        public int? DelayOver30 { get; set; }
        public int PreDelayOver30 { get; set; }
        public int? Delay3060 { get; set; }
        public int PreDelay3060 { get; set; }
        public int? Delay60120 { get; set; }
        public int PreDelay60120 { get; set; }
        public int? Delay120180 { get; set; }
        public int PreDelay120180 { get; set; }
        public int? DelayOver180 { get; set; }
        public int PreDelayOver180 { get; set; }
        public int? DelayOver240 { get; set; }
        public int PreDelayOver240 { get; set; }
        public int? FltDelayUnder30 { get; set; }
        public int PreFltDelayUnder30 { get; set; }
        public int? FltDelayOver30 { get; set; }
        public int PreFltDelayOver30 { get; set; }
        public int? FltDelay3060 { get; set; }
        public int PreFltDelay3060 { get; set; }
        public int? FltDelay60120 { get; set; }
        public int PreFltDelay60120 { get; set; }
        public int? FltDelay120180 { get; set; }
        public int PreFltDelay120180 { get; set; }
        public int? FltDelayOver180 { get; set; }
        public int PreFltDelayOver180 { get; set; }
        public int? FltDelayOver240 { get; set; }
        public int PreFltDelayOver240 { get; set; }
        public int? PaxDelayOver30 { get; set; }
        public int PrePaxDelayOver30 { get; set; }
        public int? PaxDelay3060 { get; set; }
        public int PrePaxDelay3060 { get; set; }
        public int? PaxDelay60120 { get; set; }
        public int PrePaxDelay60120 { get; set; }
        public int? FlightCount { get; set; }
        public int PreFlightCount { get; set; }
        public int? AFlightCount { get; set; }
        public int PreAFlightCount { get; set; }
        public int? BlockTime { get; set; }
        public int PreBlockTime { get; set; }
        public int? ABlockTime { get; set; }
        public int PreABlockTime { get; set; }
        public int? FlightTime { get; set; }
        public int PreFlightTime { get; set; }
        public int? AFlightTime { get; set; }
        public int PreAFlightTime { get; set; }
        public int? TotalPax { get; set; }
        public int PreTotalPax { get; set; }
        public int? ATotalPax { get; set; }
        public int PreATotalPax { get; set; }
        public int? TotalPaxAll { get; set; }
        public int PreTotalPaxAll { get; set; }
        public int? ATotalPaxAll { get; set; }
        public int PreATotalPaxAll { get; set; }
    }
}
