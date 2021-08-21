using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewCrewCalendar
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? DateContact { get; set; }
        public int? BoxId { get; set; }
        public int? FDPId { get; set; }
        public DateTime? DefaultReportingTime { get; set; }
        public DateTime? DefaultReportingTimeLocal { get; set; }
        public DateTime? DateCease { get; set; }
        public DateTime? DateCeaseLocal { get; set; }
        public DateTime? DateStartLocal { get; set; }
        public DateTime? DateEndLocal { get; set; }
        public DateTime? DateContactLocal { get; set; }
        public DateTime? DateEndActual { get; set; }
        public DateTime? DateEndActualLocal { get; set; }
        public int? Duration { get; set; }
        public decimal? Duty { get; set; }
        public int FDPReduction { get; set; }
        public int IsCeased { get; set; }
        public DateTime? RestFrom { get; set; }
        public DateTime? RestUntil { get; set; }
        public DateTime? RestFromLocal { get; set; }
        public DateTime? RestUntilLocal { get; set; }
    }
}
