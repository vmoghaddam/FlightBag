using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewDutyFDPSumShadow
    {
        public DateTime CDate { get; set; }
        public DateTime? DatePart { get; set; }
        public int? CrewId { get; set; }
        public double? Duration { get; set; }
        public double? DurationLocal { get; set; }
        public int? FDPCount { get; set; }
    }
}
