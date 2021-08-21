using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class DlyGrpFlightAirport
    {
        public int? PYear { get; set; }
        public string PMonthName { get; set; }
        public int? PMonth { get; set; }
        public string PDate { get; set; }
        public int FlightId { get; set; }
        public int? FromAirport { get; set; }
        public string FromAirportIATA { get; set; }
        public int? Delay { get; set; }
        public int? BlockTime { get; set; }
        public int? FlightTime { get; set; }
        public int? TotalPax { get; set; }
        public int? TotalPaxAll { get; set; }
        public int DelayUnder30 { get; set; }
        public int DelayOver30 { get; set; }
        public int Delay3060 { get; set; }
        public int Delay60120 { get; set; }
        public int Delay120180 { get; set; }
        public int DelayOver180 { get; set; }
        public int DelayOver240 { get; set; }
        public int? PaxDelayOver240 { get; set; }
        public int? PaxDelayOver30 { get; set; }
        public int? PaxDelay3060 { get; set; }
        public int? PaxDelay60120 { get; set; }
        public int? PaxDelay120180 { get; set; }
        public int? PaxDelayOver180 { get; set; }
    }
}
