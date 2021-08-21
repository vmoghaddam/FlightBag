using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewJobGroupType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int TypeId { get; set; }
        public string Title { get; set; }
        public string FullCode { get; set; }
        public int CustomerId { get; set; }
        public int? OrderIndex { get; set; }
    }
}
