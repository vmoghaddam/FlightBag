using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class CourseRelatedCourseType
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int CourseTypeId { get; set; }
        public string Remark { get; set; }

        public virtual Course Course { get; set; }
        public virtual CourseType CourseType { get; set; }
    }
}
