using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewDutyFlight
    {
        public DateTime CDate { get; set; }
        public DateTime? DatePart { get; set; }
        public int FDPItemId { get; set; }
        public int? FDPId { get; set; }
        public int? BoxId { get; set; }
        public int? CrewId { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? ArrivalLocal { get; set; }
        public int? Duration { get; set; }
        public int? DurationLocal { get; set; }
        public int? Positioning { get; set; }
        public int? PositioningLocal { get; set; }
    }
}
