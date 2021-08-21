using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class FDPItem
    {
        public FDPItem()
        {
            RosterCrewSheets = new HashSet<RosterCrewSheet>();
        }

        public int Id { get; set; }
        public int FDPId { get; set; }
        public int? FlightId { get; set; }
        public bool IsSector { get; set; }
        public int? SplitDutyPairId { get; set; }
        public bool? SplitDuty { get; set; }
        public bool? IsPositioning { get; set; }
        public bool? IsOff { get; set; }
        public int? PositionId { get; set; }
        public int? RosterPositionId { get; set; }
        public DateTime? Pickup { get; set; }

        public virtual FDP FDP { get; set; }
        public virtual FlightInformation Flight { get; set; }
        public virtual ICollection<RosterCrewSheet> RosterCrewSheets { get; set; }
    }
}
