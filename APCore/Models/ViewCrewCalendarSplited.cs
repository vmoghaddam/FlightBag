using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewCrewCalendarSplited
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DateLocal { get; set; }
        public int EmployeeId { get; set; }
        public int? StatusId { get; set; }
        public string Status { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateStartLocal { get; set; }
        public DateTime? DateEndLocal { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? DateContactLocal { get; set; }
        public DateTime? DateContact { get; set; }
        public int? BoxId { get; set; }
        public DateTime? DateCeaseLocal { get; set; }
        public DateTime? DateCease { get; set; }
        public int? Duration { get; set; }
        public int? ActualDuration { get; set; }
        public int IsCeased { get; set; }
        public decimal? Duty { get; set; }
        public int NightEncroach { get; set; }
        public bool IsDismissed { get; set; }
    }
}
