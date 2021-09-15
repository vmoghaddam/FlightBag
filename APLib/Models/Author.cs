using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AuthorTypeId { get; set; }
        public string Remark { get; set; }
    }
}
