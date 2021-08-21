using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewJournal
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }
        public string Website { get; set; }
        public int? Books { get; set; }
    }
}
