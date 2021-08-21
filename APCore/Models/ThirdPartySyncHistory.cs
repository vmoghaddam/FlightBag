using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ThirdPartySyncHistory
    {
        public int Id { get; set; }
        public string App { get; set; }
        public DateTime DateSync { get; set; }
        public string Remark { get; set; }
    }
}
