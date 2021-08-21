using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class CrewTypeRequirement
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int JobGroupId { get; set; }
        public int Min { get; set; }
    }
}
