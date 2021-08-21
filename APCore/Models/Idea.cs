using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class Idea
    {
        public string PID { get; set; }
        public string NID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public string ClassID { get; set; }
        public string instructor { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
        public string Days { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string issue { get; set; }
        public string expire { get; set; }
        public Guid Id { get; set; }
        public DateTime? DateIssue { get; set; }
        public DateTime? DateExpire { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}
