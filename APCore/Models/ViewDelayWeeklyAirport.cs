using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewDelayWeeklyAirport
    {
        public int PassedYear { get; set; }
        public int MonthOfYear { get; set; }
        public int WeekOfMonth { get; set; }
        public string Airport { get; set; }
        public string YearStr { get; set; }
        public string MonthStr { get; set; }
        public string WeekStr { get; set; }
        public string Title { get; set; }
        public DateTime? WeekFrom { get; set; }
        public DateTime? WeekTo { get; set; }
        public string WeekFromPersian { get; set; }
        public string WeekToPersian { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string DateFromPersian { get; set; }
        public string DateToPersian { get; set; }
        public int? Count { get; set; }
        public int? Delay { get; set; }
        public int? TotalFlights { get; set; }
        public int BlockTime { get; set; }
        public int FlightTime { get; set; }
        public double? DelayLeg { get; set; }
        public double? DelayRatio { get; set; }
    }
}
