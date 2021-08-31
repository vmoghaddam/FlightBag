using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class OFPImportProp
    {
        public int Id { get; set; }
        public int OFPId { get; set; }
        public string PropName { get; set; }
        public string PropValue { get; set; }
        public string PropType { get; set; }
        public string User { get; set; }
        public string DateUpdate { get; set; }

        public virtual OFPImport OFP { get; set; }
    }
}
