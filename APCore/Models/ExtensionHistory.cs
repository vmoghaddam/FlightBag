using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ExtensionHistory
    {
        public int Id { get; set; }
        public int FDPId { get; set; }
        public int CrewId { get; set; }
        public int? Extension { get; set; }
        public DateTime? DutyStart { get; set; }
        public int? Sectors { get; set; }
        public string Remark { get; set; }

        public virtual FDP FDP { get; set; }
    }
}
