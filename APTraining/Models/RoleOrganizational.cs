using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class RoleOrganizational
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? CompanyTypeId { get; set; }
        public string Remark { get; set; }
    }
}
