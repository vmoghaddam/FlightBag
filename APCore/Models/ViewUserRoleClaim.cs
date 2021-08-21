using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewUserRoleClaim
    {
        public string UserId { get; set; }
        public string roleId { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string Claim { get; set; }
    }
}
