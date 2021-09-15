using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class DelayAvgByRegister
    {
        public int RegisterID { get; set; }
        public string Register { get; set; }
        public int? Avg { get; set; }
    }
}
