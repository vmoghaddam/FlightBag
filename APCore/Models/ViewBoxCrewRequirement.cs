using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewBoxCrewRequirement
    {
        public int? TypeId { get; set; }
        public int Id { get; set; }
        public int FlightPlanId { get; set; }
        public DateTime? Date { get; set; }
        public int? CalanderId { get; set; }
        public int JobGroupId { get; set; }
        public int Min { get; set; }
        public int? Assigned { get; set; }
    }
}
