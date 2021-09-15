using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class SumEmployeeLocation
    {
        public int CustomerId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int? Count { get; set; }
    }
}
