using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class CourseType
    {
        public CourseType()
        {
            CourseRelatedCourseTypes = new HashSet<CourseRelatedCourseType>();
            CourseTypeJobGroups = new HashSet<CourseTypeJobGroup>();
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public int? CalenderTypeId { get; set; }
        public int? CourseCategoryId { get; set; }
        public int? LicenseResultBasicId { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }
        public int? Interval { get; set; }
        public bool? IsGeneral { get; set; }
        public bool? Status { get; set; }
        public int? Duration { get; set; }
        public int? CertificateTypeId { get; set; }

        public virtual CertificateType CertificateType { get; set; }
        public virtual CourseCategory CourseCategory { get; set; }
        public virtual LicenseResultBasic LicenseResultBasic { get; set; }
        public virtual ICollection<CourseRelatedCourseType> CourseRelatedCourseTypes { get; set; }
        public virtual ICollection<CourseTypeJobGroup> CourseTypeJobGroups { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
