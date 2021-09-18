using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class HelperFlightPlanRegisterAssigned
    {
        public int flightplanid { get; set; }
        public int PlannedRegisterId { get; set; }
        public DateTime? MinDateFrom { get; set; }
        public DateTime? MaxDateTo { get; set; }
    }
}
