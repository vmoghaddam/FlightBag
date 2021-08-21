using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class CoursePerson
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int? PersonId { get; set; }
        public int? EmployeeId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? DateStatus { get; set; }
        public DateTime? DateIssue { get; set; }
        public DateTime? DateExpire { get; set; }
        public string StatusRemark { get; set; }
        public string CertificateNo { get; set; }

        public virtual Course Course { get; set; }
    }
}
