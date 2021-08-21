using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class CourseCatRate
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int CatRateId { get; set; }
        public string Remark { get; set; }

        public virtual Course Course { get; set; }
    }
}
