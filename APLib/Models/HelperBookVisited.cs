using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class HelperBookVisited
    {
        public int EmployeeId { get; set; }
        public int BookId { get; set; }
        public bool? IsVisited { get; set; }
    }
}
