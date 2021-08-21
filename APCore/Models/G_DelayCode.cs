using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class G_DelayCode
    {
        public G_DelayCode()
        {
            InverseParent = new HashSet<G_DelayCode>();
        }

        public int ID { get; set; }
        public int? ParentID { get; set; }
        public string Title { get; set; }
        public string DelayCode { get; set; }
        public string Description { get; set; }

        public virtual G_DelayCode Parent { get; set; }
        public virtual ICollection<G_DelayCode> InverseParent { get; set; }
    }
}
