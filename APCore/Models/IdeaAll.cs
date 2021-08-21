using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class IdeaAll
    {
        public int Id { get; set; }
        public string IdeaId { get; set; }
        public string NID { get; set; }
        public string PID { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public string ClassID { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public string OriginalStr { get; set; }
        public string Remark { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateExpire { get; set; }
    }
}
