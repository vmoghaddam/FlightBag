using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class CourseSessionPresence
    {
        public int Id { get; set; }
        public int? SessionId { get; set; }
        public DateTime? Date { get; set; }
        public string Remark { get; set; }
        public int? PersonId { get; set; }
        public string SessionKey { get; set; }
        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Person Person { get; set; }
    }
}
