using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class CertificateType
    {
        public CertificateType()
        {
            CourseTypes = new HashSet<CourseType>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<CourseType> CourseTypes { get; set; }
    }
}
