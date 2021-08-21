using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class FDPMaxDaily
    {
        public int Id { get; set; }
        public DateTime? DutyStart { get; set; }
        public DateTime? DutyEnd { get; set; }
        public int? Sectors { get; set; }
        public int? MaxFDP { get; set; }
        public TimeSpan? MaxFDPH { get; set; }
    }
}
