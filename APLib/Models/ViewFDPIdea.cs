using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class ViewFDPIdea
    {
        public int Id { get; set; }
        public int? CrewId { get; set; }
        public string InitFlts { get; set; }
        public string InitRoute { get; set; }
        public DateTime? DutyStart { get; set; }
        public int DutyType { get; set; }
        public DateTime? RestUntil { get; set; }
    }
}
