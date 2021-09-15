using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class DelayAvgByCategory
    {
        public string Category { get; set; }
        public int? Avg { get; set; }
    }
}
