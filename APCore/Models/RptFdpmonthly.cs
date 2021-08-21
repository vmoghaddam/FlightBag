using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class RptFDPMonthly
    {
        public int? Year { get; set; }
        public int? Month { get; set; }
        public string MonthName { get; set; }
        public int? CrewId { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
        public string JobGroup { get; set; }
        public string JobGroupCode { get; set; }
        public string JobGroupRoot { get; set; }
        public int? FlightTime { get; set; }
        public int? BlockTime { get; set; }
        public int? FixTime { get; set; }
        public int? ScheduledTime { get; set; }
        public int? Legs { get; set; }
        public int? Leg1 { get; set; }
        public int? Leg2 { get; set; }
        public int? Leg3 { get; set; }
        public int? Leg4 { get; set; }
        public int? Leg5 { get; set; }
        public int? Leg6 { get; set; }
        public int? Leg7 { get; set; }
        public int? Leg8 { get; set; }
    }
}
