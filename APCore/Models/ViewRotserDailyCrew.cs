using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewRotserDailyCrew
    {
        public int Id { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public int GroupOrder { get; set; }
        public string JobGroup { get; set; }
        public int? GroupId { get; set; }
        public string JobGroupCode { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
    }
}
