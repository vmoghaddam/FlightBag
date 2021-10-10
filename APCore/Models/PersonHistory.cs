using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class PersonHistory
    {
        public int Id { get; set; }
        public int? PersonId { get; set; }
        public string Remark { get; set; }
        public string User { get; set; }
        public DateTime? DateCreate { get; set; }
    }
}
