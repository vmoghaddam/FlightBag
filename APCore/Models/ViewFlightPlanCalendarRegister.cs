using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFlightPlanCalendarRegister
    {
        public DateTime? Date { get; set; }
        public int PlannedRegisterId { get; set; }
        public int RegisterId { get; set; }
        public int FlightPlanId { get; set; }
    }
}
