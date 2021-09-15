using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class JobGroup
    {
        public JobGroup()
        {
            BookRelatedGroups = new HashSet<BookRelatedGroup>();
            CourseRelatedGroups = new HashSet<CourseRelatedGroup>();
            CourseTypeJobGroups = new HashSet<CourseTypeJobGroup>();
            InverseParent = new HashSet<JobGroup>();
            PersonCustomers = new HashSet<PersonCustomer>();
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string FullCode { get; set; }
        public string Remark { get; set; }
        public int CustomerId { get; set; }

        public virtual JobGroup Parent { get; set; }
        public virtual ICollection<BookRelatedGroup> BookRelatedGroups { get; set; }
        public virtual ICollection<CourseRelatedGroup> CourseRelatedGroups { get; set; }
        public virtual ICollection<CourseTypeJobGroup> CourseTypeJobGroups { get; set; }
        public virtual ICollection<JobGroup> InverseParent { get; set; }
        public virtual ICollection<PersonCustomer> PersonCustomers { get; set; }
    }
}
