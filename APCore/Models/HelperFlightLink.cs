using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class HelperFlightLink
    {
        public int Flight1Id { get; set; }
        public int Flight2Id { get; set; }
        public int ReasonId { get; set; }
        public string Remark { get; set; }
        public string Reason { get; set; }
        public string FlightNumber { get; set; }
    }
}
