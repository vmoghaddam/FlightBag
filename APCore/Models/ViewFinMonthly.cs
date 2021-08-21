using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFinMonthly
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string YearName { get; set; }
        public string MonthName { get; set; }
        public string YearMonth { get; set; }
        public int? Legs { get; set; }
        public int Child { get; set; }
        public int Infant { get; set; }
        public int Adult { get; set; }
        public int TotalPax { get; set; }
        public int TotalSeat { get; set; }
        public int Delay { get; set; }
        public decimal UpliftFuel { get; set; }
        public decimal UsedFuel { get; set; }
    }
}
