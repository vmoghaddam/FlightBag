using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class SumEmployeeMaritalStatus
    {
        public int CustomerId { get; set; }
        public int MarriageId { get; set; }
        public string MaritalStatus { get; set; }
        public int? Count { get; set; }
    }
}
