using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class DelayAvgByAirportCategory
    {
        public int FromAirport { get; set; }
        public string FromAirportIATA { get; set; }
        public string Category { get; set; }
        public int? Avg { get; set; }
    }
}
