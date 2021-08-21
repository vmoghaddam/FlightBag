using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class HelperBoxCrewTime
    {
        public int BoxId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? Date { get; set; }
        public int? CalanderId { get; set; }
        public int? Duty { get; set; }
        public int? Flight { get; set; }
    }
}
