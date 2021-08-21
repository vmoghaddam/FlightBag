using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFTL
    {
        public DateTime Date { get; set; }
        public int CrewId { get; set; }
        public double? Duty1Local { get; set; }
        public double? Duty7Local { get; set; }
        public double? Duty14Local { get; set; }
        public double? Duty28Local { get; set; }
        public double? Flight1Local { get; set; }
        public double? Flight28Local { get; set; }
        public double? FlightYearLocal { get; set; }
        public double? FlightCYearLocal { get; set; }
        public int? _Flight1Local { get; set; }
        public int? _Flight28Local { get; set; }
        public int? _FlightYearLocal { get; set; }
    }
}
