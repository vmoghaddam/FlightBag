using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class HelperDutyStart
    {
        public int Id { get; set; }
        public int? CrewId { get; set; }
        public DateTime? DutyStart { get; set; }
    }
}
