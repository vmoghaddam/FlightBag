using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class SumBoxTime
    {
        public int? BoxId { get; set; }
        public DateTime? Date { get; set; }
        public int? CalanderId { get; set; }
        public int? Duty { get; set; }
        public int? FDP { get; set; }
        public int? Flight { get; set; }
        public int? Sector { get; set; }
    }
}
