using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class CourseSessionFDP
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int FDPId { get; set; }
        public string SessionKey { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual FDP FDP { get; set; }
    }
}
