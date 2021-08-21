using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class BoxFlightPlanItem
    {
        public int Id { get; set; }
        public int BoxId { get; set; }
        public int ItemId { get; set; }
        public int CalanderId { get; set; }
        public bool? SplitDuty { get; set; }
        public int? SplitDutyPairId { get; set; }

        public virtual Box Box { get; set; }
    }
}
