using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class DelayAvgByRegisterCategory
    {
        public int RegisterID { get; set; }
        public string Register { get; set; }
        public string Category { get; set; }
        public int? Avg { get; set; }
    }
}
