using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class G_OpOneDelayType
    {
        public Guid PKG_OpOneDelayType { get; set; }
        public string Title { get; set; }
        public string DelayCodeStartWith { get; set; }
        public string Description { get; set; }
    }
}
