using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class FlightPlanDay
    {
        public int FlightPlanId { get; set; }
        public int Day { get; set; }

        public virtual FlightPlan FlightPlan { get; set; }
    }
}
