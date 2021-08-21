using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class CrewAvailability
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public int PersonId { get; set; }
        public string Remark { get; set; }
    }
}
