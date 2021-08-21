using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class HelperMatchingList
    {
        public long RN { get; set; }
        public int? FlightId { get; set; }
        public double? FirstCrewId { get; set; }
        public double? SecondCrewId { get; set; }
        public int? TemplateId { get; set; }
    }
}
