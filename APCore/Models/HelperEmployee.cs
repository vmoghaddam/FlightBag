using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class HelperEmployee
    {
        public int Id { get; set; }
        public int SexId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
        public int PersonId { get; set; }
    }
}
