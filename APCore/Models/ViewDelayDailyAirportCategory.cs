using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewDelayDailyAirportCategory
    {
        public DateTime? Date { get; set; }
        public string DayName { get; set; }
        public string YearName { get; set; }
        public string PDate { get; set; }
        public string PYearName { get; set; }
        public string PMonthName { get; set; }
        public string PDayName { get; set; }
        public string Airport { get; set; }
        public string Category { get; set; }
        public int Delay { get; set; }
        public int Count { get; set; }
        public int? TotalFlights { get; set; }
        public int BlockTime { get; set; }
        public int FlightTime { get; set; }
        public double? DelayLeg { get; set; }
        public double? DelayRatio { get; set; }
        public double? TRND { get; set; }
        public double? TRNDLeg { get; set; }
    }
}
