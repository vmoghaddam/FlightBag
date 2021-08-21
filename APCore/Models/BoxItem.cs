using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class BoxItem
    {
        public int Id { get; set; }
        public int BoxId { get; set; }
        public int PlanItemId { get; set; }

        public virtual Box Box { get; set; }
        public virtual FlightPlanItem PlanItem { get; set; }
    }
}
