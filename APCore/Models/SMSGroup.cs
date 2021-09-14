using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class SMSGroup
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
