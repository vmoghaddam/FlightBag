using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class FlightPlanMonth
    {
        public int FlightPlanId { get; set; }
        public int Month { get; set; }

        public virtual FlightPlan FlightPlan { get; set; }
    }
}
