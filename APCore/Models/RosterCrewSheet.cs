using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class RosterCrewSheet
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public int CrewId { get; set; }
        public bool DH { get; set; }
        public int PositionId { get; set; }
        public int? FDPItemId { get; set; }

        public virtual FDPItem FDPItem { get; set; }
    }
}
