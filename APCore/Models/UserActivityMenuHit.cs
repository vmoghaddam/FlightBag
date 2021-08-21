using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class UserActivityMenuHit
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ModuleId { get; set; }
        public string Key { get; set; }
        public int? CustomerId { get; set; }
        public int Hit { get; set; }
        public DateTime DateLastHit { get; set; }
    }
}
