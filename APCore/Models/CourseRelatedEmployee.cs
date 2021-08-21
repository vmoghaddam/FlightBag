using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class CourseRelatedEmployee
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int EmployeeId { get; set; }
        public string Remark { get; set; }

        public virtual Course Course { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
