using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class XCrewAssignedRpt
    {
        public string SCH { get; set; }
        public string CODE { get; set; }
        public string PDATE { get; set; }
        public DateTime? DATE { get; set; }
        public string FN { get; set; }
        public int? FlightId { get; set; }
        public int? CrewId2 { get; set; }
        public string Name { get; set; }
        public string JobGroup { get; set; }
        public int? groupid { get; set; }
    }
}
