using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class Index
    {
        public int Id { get; set; }
        public DateTime? Std { get; set; }
        public DateTime? Sta { get; set; }
    }
}
