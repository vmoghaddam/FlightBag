using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class ViewStudyField
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
