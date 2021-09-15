using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class SumEmployeeJobGroup
    {
        public int CustomerId { get; set; }
        public string GroupCode { get; set; }
        public string RootTitle { get; set; }
        public int? Count { get; set; }
    }
}
