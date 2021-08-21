using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class BookChapter
    {
        public BookChapter()
        {
            InverseParent = new HashSet<BookChapter>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public string Remark { get; set; }
        public string Code { get; set; }
        public string FullCode { get; set; }
        public int? BookId { get; set; }
        public string BookKey { get; set; }

        public virtual Book Book { get; set; }
        public virtual BookChapter Parent { get; set; }
        public virtual ICollection<BookChapter> InverseParent { get; set; }
    }
}
