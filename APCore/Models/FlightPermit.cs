using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class FlightPermit
    {
        public FlightPermit()
        {
            FlightPlanItemPermits = new HashSet<FlightPlanItemPermit>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<FlightPlanItemPermit> FlightPlanItemPermits { get; set; }
    }
}
