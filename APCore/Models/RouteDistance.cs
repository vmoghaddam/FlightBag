using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class RouteDistance
    {
        public int Id { get; set; }
        public string FromIATA { get; set; }
        public int FromId { get; set; }
        public string ToIATA { get; set; }
        public int ToId { get; set; }
        public double? Distance { get; set; }
    }
}
