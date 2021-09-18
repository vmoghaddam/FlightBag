using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class FDPVisibleDate
    {
        public int Id { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string UserName { get; set; }
    }
}
