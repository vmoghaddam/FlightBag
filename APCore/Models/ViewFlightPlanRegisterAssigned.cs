using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFlightPlanRegisterAssigned
    {
        public int id { get; set; }
        public int? DesignedRegisterCount { get; set; }
        public int? CompletedAssignedRegisterCount { get; set; }
        public int? NotCompletedAssignedRegisterCount { get; set; }
    }
}
