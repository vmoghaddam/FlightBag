using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewPersonDocument
    {
        public int PersonId { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }
        public int DocumentTypeId { get; set; }
        public int Id { get; set; }
        public string DocumentType { get; set; }
    }
}
