using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class HelperRestPeriod
    {
        public int? CrewId { get; set; }
        public DateTime? RestFrom { get; set; }
        public DateTime? RestUntil { get; set; }
        public DateTime? RestFromLocal { get; set; }
        public DateTime? RestUntilLocal { get; set; }
        public int FDPId { get; set; }
    }
}
