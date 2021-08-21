using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewOffItem
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public int? CrewId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
        public string Remark { get; set; }
    }
}
