using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class SumEmployeeStudyField
    {
        public int CustomerId { get; set; }
        public int StudyFieldId { get; set; }
        public string StudyField { get; set; }
        public int? Count { get; set; }
    }
}
