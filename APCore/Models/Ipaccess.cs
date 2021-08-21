using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class IPAccess
    {
        public int Id { get; set; }
        public string IP { get; set; }
        public string UserId { get; set; }
        public bool? Role { get; set; }
    }
}
