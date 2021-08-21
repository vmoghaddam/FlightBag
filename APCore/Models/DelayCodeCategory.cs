using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class DelayCodeCategory
    {
        public DelayCodeCategory()
        {
            DelayCodes = new HashSet<DelayCode>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }
        public string MainCategory { get; set; }

        public virtual ICollection<DelayCode> DelayCodes { get; set; }
    }
}
