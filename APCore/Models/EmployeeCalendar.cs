using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class EmployeeCalendar
    {
        public EmployeeCalendar()
        {
            EmployeeCalendarSpliteds = new HashSet<EmployeeCalendarSplited>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        public int StatusId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? DateContact { get; set; }
        public int? BoxId { get; set; }
        public DateTime? DateCease { get; set; }
        public bool? IsHomeBase { get; set; }
        public int? FDPId { get; set; }

        public virtual FDP FDP { get; set; }
        public virtual ICollection<EmployeeCalendarSplited> EmployeeCalendarSpliteds { get; set; }
    }
}
