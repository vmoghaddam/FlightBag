using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFolderApplicable
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string FullCode { get; set; }
        public int EmployeeId { get; set; }
        public int? Items { get; set; }
        public int? Files { get; set; }
        public int? NotVisited { get; set; }
        public int? NotDownloaded { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeCustomerId { get; set; }
    }
}
