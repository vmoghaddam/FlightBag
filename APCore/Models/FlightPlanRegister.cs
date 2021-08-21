using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class FlightPlanRegister
    {
        public int Id { get; set; }
        public int FlightPlanId { get; set; }
        public int PlannedRegisterId { get; set; }
        public int RegisterId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Remark { get; set; }
        public DateTime? Date { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? DateApproved { get; set; }
        public int? ApproverId { get; set; }
        public int? CalendarId { get; set; }

        public virtual FlightPlan FlightPlan { get; set; }
        public virtual Ac_MSN PlannedRegister { get; set; }
        public virtual Ac_MSN Register { get; set; }
    }
}
