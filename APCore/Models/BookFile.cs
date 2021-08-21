using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class BookFile
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int DocumentId { get; set; }
        public string Remark { get; set; }
        public int? ChapterId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Document Document { get; set; }
    }
}
