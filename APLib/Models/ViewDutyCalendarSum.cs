using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class ViewDutyCalendarSum
    {
        public DateTime CDate { get; set; }
        public DateTime? DatePart { get; set; }
        public int EmployeeId { get; set; }
        public decimal? Duration { get; set; }
        public decimal? DurationLocal { get; set; }
        public int? CalendarCount { get; set; }
    }
}
