using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class EmployeeCalendarSplited
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? DateContact { get; set; }
        public int? BoxId { get; set; }
        public DateTime? DateCease { get; set; }
        public bool? IsHomeBase { get; set; }
        public int EmployeeId { get; set; }
        public bool IsDismissed { get; set; }
        public int? StatusId { get; set; }

        public virtual BoxCrew Box { get; set; }
        public virtual EmployeeCalendar Master { get; set; }
    }
}
