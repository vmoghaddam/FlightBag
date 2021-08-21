using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewBookChapter
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public string Remark { get; set; }
        public string Code { get; set; }
        public string Fullcode { get; set; }
        public int? BookId { get; set; }
        public string BookKey { get; set; }
        public string TitleFormated { get; set; }
        public string TitleFormatedSpace { get; set; }
        public int? Files { get; set; }
    }
}
