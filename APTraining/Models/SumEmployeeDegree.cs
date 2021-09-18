using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class SumEmployeeDegree
    {
        public int CustomerId { get; set; }
        public int EducationDegreeId { get; set; }
        public string EducationDegree { get; set; }
        public int? Count { get; set; }
    }
}
