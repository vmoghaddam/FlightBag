using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class FlighPlanCalendar
    {
        public FlighPlanCalendar()
        {
            FlightPlanCalanderCrews = new HashSet<FlightPlanCalanderCrew>();
        }

        public int Id { get; set; }
        public int FlightPlanId { get; set; }
        public DateTime? Date { get; set; }

        public virtual FlightPlan FlightPlan { get; set; }
        public virtual ICollection<FlightPlanCalanderCrew> FlightPlanCalanderCrews { get; set; }
    }
}
