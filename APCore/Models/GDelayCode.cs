using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class GDelayCode
    {
        public GDelayCode()
        {
            InverseParent = new HashSet<GDelayCode>();
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string DelayCode { get; set; }
        public string Description { get; set; }

        public virtual GDelayCode Parent { get; set; }
        public virtual ICollection<GDelayCode> InverseParent { get; set; }
    }
}
