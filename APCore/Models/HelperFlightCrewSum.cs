using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class HelperFlightCrewSum
    {
        public int FlightId { get; set; }
        public int Males { get; set; }
        public int Females { get; set; }
        public int? Total { get; set; }
    }
}
