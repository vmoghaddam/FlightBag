using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class UpdatedPlanFlight
    {
        public int Id { get; set; }
        public int? PlanId { get; set; }
        public int? PlanItemId { get; set; }
        public int? FlightId { get; set; }
        public DateTime? Date { get; set; }
        public int? Status { get; set; }
    }
}
