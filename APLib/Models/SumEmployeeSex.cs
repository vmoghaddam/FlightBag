using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class SumEmployeeSex
    {
        public int CustomerId { get; set; }
        public int SexId { get; set; }
        public string Sex { get; set; }
        public int? Count { get; set; }
    }
}
