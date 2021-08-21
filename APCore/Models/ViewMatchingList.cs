using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewMatchingList
    {
        public int Id { get; set; }
        public int FirstCrewId { get; set; }
        public int SecondCrewId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool IsActive { get; set; }
        public string FirstCrew { get; set; }
        public string SecondCrew { get; set; }
        public string FirstJobGroup { get; set; }
        public string SecondJobGroup { get; set; }
    }
}
