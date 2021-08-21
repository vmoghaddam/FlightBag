using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class DayGp1
    {
        public DateTime Gdate { get; set; }
        public string Pdate { get; set; }
        public string PyearName { get; set; }
        public int? Pyear { get; set; }
        public string PmonthName { get; set; }
        public int? Pmonth { get; set; }
        public string PdayName { get; set; }
        public int? UtcDiff { get; set; }
        public DateTime? LocalDate { get; set; }
        public string PeriodFixTime { get; set; }
        public int? Pdate2 { get; set; }
    }
}
