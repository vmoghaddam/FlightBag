using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class Chapter
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int? ParentId { get; set; }
        public string Code { get; set; }
        public string Remark { get; set; }

        public virtual Book Book { get; set; }
    }
}
