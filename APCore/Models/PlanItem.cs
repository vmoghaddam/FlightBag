using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class PlanItem
    {
        public int Id { get; set; }
        public DateTime? DateFrom { get; set; }
        public string Day { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public DateTime Dep { get; set; }
        public DateTime Arr { get; set; }
        public int TypeId { get; set; }
        public DateTime? DateTo { get; set; }
        public string FlightNumber { get; set; }
        public int? FlightH { get; set; }
        public int? FlightM { get; set; }
        public string Line { get; set; }
    }
}
