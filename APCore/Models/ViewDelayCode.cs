using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewDelayCode
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string CategoryRemark { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int? CodeNumber { get; set; }
        public int DelayCategoryId { get; set; }
        public string Remark { get; set; }
        public int? AirlineId { get; set; }
        public string ICategory { get; set; }
    }
}
