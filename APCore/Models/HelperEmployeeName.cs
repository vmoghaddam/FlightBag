using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class HelperEmployeeName
    {
        public int Id { get; set; }
        public string PID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public int PersonId { get; set; }
    }
}
