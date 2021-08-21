using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class HelperFuelMonthlyDay
    {
        public int? Year { get; set; }
        public int? Month { get; set; }
        public string MonthName { get; set; }
        public decimal Used { get; set; }
        public decimal? MaxUsed { get; set; }
    }
}
