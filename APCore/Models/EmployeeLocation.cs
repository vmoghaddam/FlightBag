using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class EmployeeLocation
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int LocationId { get; set; }
        public bool IsMainLocation { get; set; }
        public int? OrgRoleId { get; set; }
        public decimal? DateActiveStartP { get; set; }
        public decimal? DateActiveEndP { get; set; }
        public DateTime? DateActiveStart { get; set; }
        public DateTime? DateActiveEnd { get; set; }
        public string Remark { get; set; }
        public string Phone { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Location Location { get; set; }
    }
}
