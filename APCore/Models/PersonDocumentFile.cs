using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class PersonDocumentFile
    {
        public int DocumentId { get; set; }
        public int PersonDocumentId { get; set; }

        public virtual Document Document { get; set; }
        public virtual PersonDocument PersonDocument { get; set; }
    }
}
