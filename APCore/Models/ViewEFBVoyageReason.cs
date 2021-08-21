using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewEFBVoyageReason
    {
        public int? ReasonId { get; set; }
        public int? VoyageReportId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
