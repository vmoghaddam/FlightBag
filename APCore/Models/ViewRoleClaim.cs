using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewRoleClaim
    {
        public string Id { get; set; }
        public int? RoleId { get; set; }
        public string Name2 { get; set; }
        public string Name { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string Claim { get; set; }
    }
}
