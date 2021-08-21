using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class PersonCourse
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? StatusId { get; set; }
        public string Remark { get; set; }
        public int? CourseId { get; set; }
        public bool? Quarantine { get; set; }
        public string Grade { get; set; }
        public string CerNumber { get; set; }
        public DateTime? DateIssue { get; set; }
        public DateTime? DateExpire { get; set; }
        public decimal? DateIssueP { get; set; }
        public decimal? DateExpireP { get; set; }
        public string CerUrl { get; set; }
        public DateTime? DateStatus { get; set; }
        public bool? StatusConfirmed { get; set; }

        public virtual Course Course { get; set; }
        public virtual Person Person { get; set; }
    }
}
