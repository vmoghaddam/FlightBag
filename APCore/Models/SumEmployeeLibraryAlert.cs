using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class SumEmployeeLibraryAlert
    {
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int TypeId { get; set; }
        public int? Count { get; set; }
    }
}
