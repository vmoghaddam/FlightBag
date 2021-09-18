using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class CourseTypeJobGroup
    {
        public int CourseTypeId { get; set; }
        public int JobGroupId { get; set; }
        public string Remark { get; set; }

        public virtual CourseType CourseType { get; set; }
        public virtual JobGroup JobGroup { get; set; }
    }
}
