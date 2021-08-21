using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class HelperFlightSexSum
    {
        public int? FlightId { get; set; }
        public int? Total { get; set; }
        public string Sex { get; set; }
        public int SexId { get; set; }
    }
}
