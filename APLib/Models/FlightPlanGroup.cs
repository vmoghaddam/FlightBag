using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class FlightPlanGroup
    {
        public int Id { get; set; }
        public int FlightPlanId { get; set; }
        public int RegisterId { get; set; }

        public virtual FlightPlanItem FlightPlan { get; set; }
    }
}
