using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class BoxCrew
    {
        public BoxCrew()
        {
            EmployeeCalendarSpliteds = new HashSet<EmployeeCalendarSplited>();
        }

        public int Id { get; set; }
        public int BoxId { get; set; }
        public int JobGroupId { get; set; }
        public int EmployeeId { get; set; }
        public int? AvailabilityId { get; set; }
        public string Remark { get; set; }
        public DateTime? ReportingTime { get; set; }

        public virtual Box Box { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<EmployeeCalendarSplited> EmployeeCalendarSpliteds { get; set; }
    }
}
