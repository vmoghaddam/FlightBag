using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class SumLibraryDownloadByMonth
    {
        public int CustomerId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
        public int? Count { get; set; }
    }
}
