using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class IrimoFlightFolderHistory
    {
        public int Id { get; set; }
        public string FL { get; set; }
        public string DT { get; set; }
        public string VT { get; set; }
        public string FileName { get; set; }
    }
}
