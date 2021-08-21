using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewCourseType
    {
        public int Id { get; set; }
        public int? CalenderTypeId { get; set; }
        public int? CourseCategoryId { get; set; }
        public int? LicenseResultBasicId { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }
        public int? Interval { get; set; }
        public string Interval2 { get; set; }
        public bool? IsGeneral { get; set; }
        public bool? Status { get; set; }
        public string Category { get; set; }
        public string CalenderType { get; set; }
        public int? CoursesCount { get; set; }
        public int? Duration { get; set; }
        public int? CertificateTypeId { get; set; }
        public string CertificateType { get; set; }
        public string JobGroups { get; set; }
        public string JobGroupsCode { get; set; }
    }
}
