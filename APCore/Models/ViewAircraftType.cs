using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewAircraftType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int ManufacturerId { get; set; }
        public string Remark { get; set; }
        public string Manufacturer { get; set; }
    }
}
