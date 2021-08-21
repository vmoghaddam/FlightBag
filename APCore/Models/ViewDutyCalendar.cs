using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewDutyCalendar
    {
        public DateTime CDate { get; set; }
        public DateTime? DatePart { get; set; }
        public int CrewCalendarId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEndActual { get; set; }
        public DateTime? DateStartLocal { get; set; }
        public DateTime? DateEndActualLocal { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }
        public int? DurationOriginal { get; set; }
        public int? DurationLocalOriginal { get; set; }
        public decimal? Duration { get; set; }
        public decimal? DurationLocal { get; set; }
    }
}
