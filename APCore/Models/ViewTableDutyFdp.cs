using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewTableDutyFDP
    {
        public DateTime CDate { get; set; }
        public int? CrewId { get; set; }
        public double? Duration { get; set; }
        public double? DurationLocal { get; set; }
    }
}
