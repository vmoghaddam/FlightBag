using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class IPAccess
    {
        public int Id { get; set; }
        public string IP { get; set; }
        public string UserId { get; set; }
        public bool? Role { get; set; }
    }
}
