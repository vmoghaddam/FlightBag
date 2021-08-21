using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class BookRelatedEmployee
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int BookId { get; set; }
        public string Remark { get; set; }
        public DateTime? DateSigned { get; set; }

        public virtual Book Book { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
