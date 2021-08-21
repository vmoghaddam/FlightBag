using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class FlightLink
    {
        public int Flight1Id { get; set; }
        public int Flight2Id { get; set; }
        public int ReasonId { get; set; }
        public string Remark { get; set; }

        public virtual FlightInformation Flight1 { get; set; }
        public virtual FlightInformation Flight2 { get; set; }
    }
}
