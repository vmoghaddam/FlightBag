using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class DelayAvgByCategory
    {
        public string Category { get; set; }
        public int? Avg { get; set; }
    }
}
