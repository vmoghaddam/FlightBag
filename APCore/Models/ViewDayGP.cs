using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewDayGP
    {
        public DateTime GDate { get; set; }
        public string PDate { get; set; }
        public string PYearName { get; set; }
        public int? PYear { get; set; }
        public string PMonthName { get; set; }
        public int? PMonth { get; set; }
        public string PDayName { get; set; }
        public int? UtcDiff { get; set; }
        public DateTime? LocalDate { get; set; }
        public string PeriodFixTime { get; set; }
        public int? PDate2 { get; set; }
        public int? PDay { get; set; }
    }
}
