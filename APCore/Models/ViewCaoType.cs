using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewCaoType
    {
        public int Id { get; set; }
        public int? AircraftTypeId { get; set; }
        public string Title { get; set; }
        public string CaoGroup { get; set; }
        public string Remark { get; set; }
    }
}
