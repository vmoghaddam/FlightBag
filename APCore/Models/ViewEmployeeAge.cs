using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewEmployeeAge
    {
        public int? CustomerId { get; set; }
        public int Id { get; set; }
        public int? Age { get; set; }
        public int AgeUnknown { get; set; }
        public int Age0025 { get; set; }
        public int Age2530 { get; set; }
        public int Age3040 { get; set; }
        public int Age4050 { get; set; }
        public int Age5000 { get; set; }
    }
}
