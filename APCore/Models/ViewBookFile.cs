using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewBookFile
    {
        public string Title { get; set; }
        public string FileUrl { get; set; }
        public string Remark { get; set; }
        public int DocumentId { get; set; }
        public string SysUrl { get; set; }
        public string FileType { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? FileTypeId { get; set; }
        public int? ParentId { get; set; }
        public int BookId { get; set; }
        public int Id { get; set; }
        public int? ChapterId { get; set; }
        public string Chapter { get; set; }
    }
}
