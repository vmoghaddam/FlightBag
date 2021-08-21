using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class FixTimeRoute
    {
        public string Route { get; set; }
        public int? FixtTime { get; set; }
        public TimeSpan FixTime2 { get; set; }
    }
}
