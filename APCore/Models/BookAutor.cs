using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class BookAutor
    {
        public int Id { get; set; }
        public int PersonMiscId { get; set; }
        public int TypeId { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
        public virtual PersonMisc PersonMisc { get; set; }
    }
}
