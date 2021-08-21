using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewDelayMonthlyAirportCategory
    {
        public string Category { get; set; }
        public string Airport { get; set; }
        public int PassedYear { get; set; }
        public int MonthOfYear { get; set; }
        public string YearStr { get; set; }
        public string MonthStr { get; set; }
        public string Title { get; set; }
        public DateTime? MonthFrom { get; set; }
        public DateTime? MonthTo { get; set; }
        public string MonthFromPersian { get; set; }
        public string MonthToPersian { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string DateFromPersian { get; set; }
        public string DateToPersian { get; set; }
        public int? Count { get; set; }
        public int? Delay { get; set; }
        public int? TotalFlights { get; set; }
        public int? BlockTime { get; set; }
        public int? FlightTime { get; set; }
        public double? DelayLeg { get; set; }
        public double? DelayRatio { get; set; }
    }
}
