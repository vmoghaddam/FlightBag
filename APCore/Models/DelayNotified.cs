using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class DelayNotified
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public int? Delay { get; set; }
        public int? TypeId { get; set; }
    }
}
