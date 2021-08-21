using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class CourseCategory
    {
        public CourseCategory()
        {
            CourseTypes = new HashSet<CourseType>();
            InverseParent = new HashSet<CourseCategory>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }

        public virtual CourseCategory Parent { get; set; }
        public virtual ICollection<CourseType> CourseTypes { get; set; }
        public virtual ICollection<CourseCategory> InverseParent { get; set; }
    }
}
