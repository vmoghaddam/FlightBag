using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class NOTAMItem
    {
        public int Id { get; set; }
        public int NOTAMId { get; set; }
        public string Text { get; set; }

        public virtual NOTAM NOTAM { get; set; }
    }
}
