using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class ViewFlightPlanCalendarRegisterAll
    {
        public DateTime? Date { get; set; }
        public int PlannedRegisterId { get; set; }
        public int RegisterId { get; set; }
        public int FlightPlanId { get; set; }
    }
}
