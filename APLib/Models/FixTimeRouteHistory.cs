using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class FixTimeRouteHistory
    {
        public int Id { get; set; }
        public string Route { get; set; }
        public TimeSpan? OldTime { get; set; }
        public TimeSpan? NewTime { get; set; }
        public string UserName { get; set; }
        public DateTime? Date { get; set; }
    }
}
