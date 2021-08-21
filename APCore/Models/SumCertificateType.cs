using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class SumCertificateType
    {
        public int CustomerId { get; set; }
        public int CourseTypeId { get; set; }
        public string CourseTypeTitle { get; set; }
        public int? Count { get; set; }
    }
}
