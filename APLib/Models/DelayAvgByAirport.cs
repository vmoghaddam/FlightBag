using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class DelayAvgByAirport
    {
        public int FromAirport { get; set; }
        public string FromAirportIATA { get; set; }
        public int? Avg { get; set; }
    }
}
