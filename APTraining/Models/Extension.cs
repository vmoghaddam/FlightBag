using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class Extension
    {
        public int Id { get; set; }
        public DateTime? DutyStart { get; set; }
        public DateTime? DutyEnd { get; set; }
        public int? Sectors { get; set; }
        public int? MaxFDP { get; set; }
        public TimeSpan? MaxFDPH { get; set; }
    }
}
