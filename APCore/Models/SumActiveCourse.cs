using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class SumActiveCourse
    {
        public int CustomerId { get; set; }
        public int StatusId { get; set; }
        public int? Count { get; set; }
        public int? Assigned { get; set; }
        public int? Registered { get; set; }
        public int? Unregistered { get; set; }
        public int? ActiveLearner { get; set; }
        public int? Canceled { get; set; }
        public int? DoneLearner { get; set; }
        public int? Passed { get; set; }
        public int? Failed { get; set; }
    }
}
