using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewOption
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public bool? IsSystem { get; set; }
        public int? OrderIndex { get; set; }
        public string Parent { get; set; }
        public int? CreatorId { get; set; }
        public string Prop1 { get; set; }
    }
}
