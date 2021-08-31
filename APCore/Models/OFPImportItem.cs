using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class OFPImportItem
    {
        public int Id { get; set; }
        public int OFPId { get; set; }
        public string Line { get; set; }

        public virtual OFPImport OFP { get; set; }
    }
}
