using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewEmployeeLocation
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
        public string OrgRole { get; set; }
        public string Title { get; set; }
        public string FullCode { get; set; }
        public int CustomerId { get; set; }
        public string Root2Code { get; set; }
        public string Root2Title { get; set; }
    }
}
