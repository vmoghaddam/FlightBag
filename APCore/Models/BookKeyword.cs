using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class BookKeyword
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Value { get; set; }

        public virtual Book Book { get; set; }
    }
}
