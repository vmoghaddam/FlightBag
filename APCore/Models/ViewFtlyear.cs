using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFTLYear
    {
        public DateTime Date { get; set; }
        public int CrewId { get; set; }
        public double? Duty1Local { get; set; }
        public double? Duty7Local { get; set; }
        public double? Duty14Local { get; set; }
        public double? Duty28Local { get; set; }
        public int? Flight1Local { get; set; }
        public int? Flight28Local { get; set; }
        public int? FlightYearLocal { get; set; }
    }
}
