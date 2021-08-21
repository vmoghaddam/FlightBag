using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class PersonDocument
    {
        public PersonDocument()
        {
            PersonDocumentFiles = new HashSet<PersonDocumentFile>();
        }

        public int PersonId { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }
        public int Id { get; set; }
        public int DocumentTypeId { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<PersonDocumentFile> PersonDocumentFiles { get; set; }
    }
}
