using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class Journal
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }
        public string Website { get; set; }
    }
}
