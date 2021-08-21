using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class HelperFlightPlanItemCrew
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int? CalanderId { get; set; }
        public int FlightPlanItemId { get; set; }
        public int? AvailabilityId { get; set; }
    }
}
