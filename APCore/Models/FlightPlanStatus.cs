using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class FlightPlanStatus
    {
        public int Id { get; set; }
        public int FlighPlanId { get; set; }
        public int? ApproverId { get; set; }
        public DateTime DateApproved { get; set; }
        public int ApproveTypeId { get; set; }
        public string Remark { get; set; }

        public virtual Employee Approver { get; set; }
        public virtual FlightPlan FlighPlan { get; set; }
    }
}
