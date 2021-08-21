using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFlightPlanRegister
    {
        public int Id { get; set; }
        public int FlightPlanId { get; set; }
        public int PlannedRegisterId { get; set; }
        public int RegisterId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Remark { get; set; }
        public DateTime? Date { get; set; }
        public int IsLocked { get; set; }
        public int IsOpen { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? DateApproved { get; set; }
        public int? ApproverId { get; set; }
        public string PlannedRegister { get; set; }
        public string Register { get; set; }
    }
}
