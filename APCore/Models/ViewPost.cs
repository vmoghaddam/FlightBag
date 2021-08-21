using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewPost
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public bool? IsSystem { get; set; }
        public int? OrderIndex { get; set; }
        public int? CreatorId { get; set; }
        public int? People { get; set; }
    }
}
