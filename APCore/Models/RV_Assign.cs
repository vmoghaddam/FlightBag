using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class RV_Assign
    {
        public string Crew { get; set; }
        public string Route { get; set; }
        public string Rank { get; set; }
        public string JobType { get; set; }
        public string PlanDesc { get; set; }
        public string Scheduler { get; set; }
        public string DateUTC { get; set; }
        public string RouteGroup { get; set; }
        public string Id { get; set; }
    }
}
