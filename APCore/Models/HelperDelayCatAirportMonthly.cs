using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class HelperDelayCatAirportMonthly
    {
        public int? PYear { get; set; }
        public string PMonthName { get; set; }
        public int? PMonth { get; set; }
        public string ICategory { get; set; }
        public int? ICategoryId { get; set; }
        public int FromAirport { get; set; }
        public string FromAirportIATA { get; set; }
        public int Delay { get; set; }
        public int Count { get; set; }
        public decimal? DelayPerLeg { get; set; }
        public decimal? CountPerLeg { get; set; }
        public decimal? DelayPerBL { get; set; }
        public int? OnTimeFlightCount { get; set; }
        public decimal? DelayedFlightsPerAll { get; set; }
        public decimal? DelayedFlightsPerOnTime { get; set; }
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
        public int FltDelayOver30 { get; set; }
        public int FltDelay3060 { get; set; }
        public int FltDelay60120 { get; set; }
        public int FltDelay120180 { get; set; }
        public int FltDelayOver180 { get; set; }
        public int FltDelayOver240 { get; set; }
        public int FlightCount { get; set; }
        public int AFlightCount { get; set; }
        public int BlockTime { get; set; }
        public int? ABlockTime { get; set; }
        public int FlightTime { get; set; }
        public int? AFlightTime { get; set; }
    }
}
