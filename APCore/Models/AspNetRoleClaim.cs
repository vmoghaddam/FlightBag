using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class AspNetRoleClaim
    {
        public string Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public int? RoleId { get; set; }
    }
}
