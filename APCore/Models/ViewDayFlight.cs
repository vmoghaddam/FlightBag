using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewDayFlight
    {
        public DateTime Date { get; set; }
        public int CrewId { get; set; }
        public int? Duration { get; set; }
        public int? DurationLocal { get; set; }
        public int? FLT28 { get; set; }
        public int? FLT28Local { get; set; }
        public int FLTYear { get; set; }
        public int FLTCYear { get; set; }
    }
}
