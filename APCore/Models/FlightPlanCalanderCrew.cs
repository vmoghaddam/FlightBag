using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class FlightPlanCalanderCrew
    {
        public FlightPlanCalanderCrew()
        {
            FlightCrews = new HashSet<FlightCrew>();
        }

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int? FlightPlanId { get; set; }
        public int? CalanderId { get; set; }
        public int GroupId { get; set; }
        public string Remark { get; set; }
        public int? FlightPlanItemId { get; set; }
        public int? BoxId { get; set; }
        public int? AvailabilityId { get; set; }

        public virtual Box Box { get; set; }
        public virtual FlighPlanCalendar Calander { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual FlightPlanItem FlightPlanItem { get; set; }
        public virtual ICollection<FlightCrew> FlightCrews { get; set; }
    }
}
