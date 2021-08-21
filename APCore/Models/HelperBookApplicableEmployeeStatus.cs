using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class HelperBookApplicableEmployeeStatus
    {
        public int EmployeeId { get; set; }
        public int BookId { get; set; }
        public bool IsVisited { get; set; }
        public bool IsDownloaded { get; set; }
        public DateTime? DateVisit { get; set; }
        public DateTime? DateDownload { get; set; }
    }
}
