using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class LoginInfo
    {
        public int Id { get; set; }
        public string User { get; set; }
        public DateTime? DateCreate { get; set; }
        public string Info { get; set; }
        public string IP { get; set; }
        public string LocationCity { get; set; }
    }
}
