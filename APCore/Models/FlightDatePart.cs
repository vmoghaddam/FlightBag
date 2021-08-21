using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class FlightDatePart
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public DateTime DateRef { get; set; }
        public DateTime? DateAfter { get; set; }
        public DateTime? DateFrom { get; set; }
        public int? OrderIndex { get; set; }
    }
}
