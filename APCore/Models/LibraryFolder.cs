using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class LibraryFolder
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public string Remark { get; set; }
        public string Code { get; set; }
        public string FullCode { get; set; }
    }
}
