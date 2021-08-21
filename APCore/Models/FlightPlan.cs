using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class FlightPlan
    {
        public FlightPlan()
        {
            FlighPlanCalendars = new HashSet<FlighPlanCalendar>();
            FlightPlanDays = new HashSet<FlightPlanDay>();
            FlightPlanItems = new HashSet<FlightPlanItem>();
            FlightPlanMonths = new HashSet<FlightPlanMonth>();
            FlightPlanRegisters = new HashSet<FlightPlanRegister>();
            FlightPlanStatuses = new HashSet<FlightPlanStatus>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int CustomerId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DateActive { get; set; }
        public int? Interval { get; set; }
        public DateTime? DateFirst { get; set; }
        public DateTime? DateLast { get; set; }
        public int? BaseId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<FlighPlanCalendar> FlighPlanCalendars { get; set; }
        public virtual ICollection<FlightPlanDay> FlightPlanDays { get; set; }
        public virtual ICollection<FlightPlanItem> FlightPlanItems { get; set; }
        public virtual ICollection<FlightPlanMonth> FlightPlanMonths { get; set; }
        public virtual ICollection<FlightPlanRegister> FlightPlanRegisters { get; set; }
        public virtual ICollection<FlightPlanStatus> FlightPlanStatuses { get; set; }
    }
}
