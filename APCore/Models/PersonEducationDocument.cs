using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class PersonEducationDocument
    {
        public int PersonEducationId { get; set; }
        public int DocumentId { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }

        public virtual Document Document { get; set; }
        public virtual PersonEducation PersonEducation { get; set; }
    }
}
