using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class FlightCrewChangeHistory
    {
        public int Id { get; set; }
        public int FlightCrewId { get; set; }
        public int ReasonId { get; set; }
        public DateTime DateChange { get; set; }
        public int? UserId { get; set; }
        public int? NewEmployeeId { get; set; }
        public int? NewGroupId { get; set; }
        public string Remark { get; set; }
    }
}
