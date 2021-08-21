using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class RegisterGround
    {
        public int Id { get; set; }
        public int RegisterId { get; set; }
        public int GroundTypeId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateEnd { get; set; }
        public string Remark { get; set; }
    }
}
