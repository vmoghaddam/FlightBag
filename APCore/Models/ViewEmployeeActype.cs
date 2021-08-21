using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewEmployeeACType
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string AcType { get; set; }
    }
}
