using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class FlightPlanItemPermit
    {
        public int Id { get; set; }
        public int FlightPlanId { get; set; }
        public int PermitId { get; set; }
        public DateTime? Date { get; set; }
        public string Remark { get; set; }
        public DateTime? DateFlight { get; set; }
        public int? CalanderId { get; set; }

        public virtual FlightPlanItem FlightPlan { get; set; }
        public virtual FlightPermit Permit { get; set; }
    }
}
