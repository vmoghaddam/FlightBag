using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class SumCertificateStatus
    {
        public int Id { get; set; }
        public int? Expired { get; set; }
        public int? Expiring { get; set; }
        public int? Valid { get; set; }
    }
}
