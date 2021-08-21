using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewDayOffRanked
    {
        public int Id { get; set; }
        public int? CrewId { get; set; }
        public int DutyType { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public long? DutyRank { get; set; }
    }
}
