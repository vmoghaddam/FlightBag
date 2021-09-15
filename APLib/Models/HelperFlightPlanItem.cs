using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class HelperFlightPlanItem
    {
        public int Id { get; set; }
        public int? TypeId { get; set; }
        public string Type { get; set; }
        public int FlightPlanId { get; set; }
    }
}
