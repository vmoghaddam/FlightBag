using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class ViewFlightPlanCalendarRegister
    {
        public DateTime? Date { get; set; }
        public int PlannedRegisterId { get; set; }
        public int RegisterId { get; set; }
        public int FlightPlanId { get; set; }
    }
}
