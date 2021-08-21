using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class AspNetUserToken
    {
        public string UserId { get; set; }
        public int LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
