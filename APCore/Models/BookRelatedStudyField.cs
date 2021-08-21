using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class BookRelatedStudyField
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int StudyFieldId { get; set; }
        public string Remark { get; set; }

        public virtual Book Book { get; set; }
    }
}
