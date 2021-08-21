using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class DayFlight
    {
        public DateTime Date { get; set; }
        public int CrewId { get; set; }
        public int Id { get; set; }
        public double? FLTLocal { get; set; }
        public double? FLT { get; set; }
        public double? FLT28Local { get; set; }
        public double? FLT28 { get; set; }
        public double? FLTYear { get; set; }
        public double? FLTYearLocal { get; set; }
        public double? FLTCYear { get; set; }
        public double? FLTCYearLocal { get; set; }
        public double? DH { get; set; }
        public double? DHLocal { get; set; }
        public double? DH28 { get; set; }
        public double? DH28Local { get; set; }
        public double? DHYear { get; set; }
        public double? DHYearLocal { get; set; }
        public double? DHCYear { get; set; }
        public double? DHCYearLocal { get; set; }
        public int? Year { get; set; }
    }
}
