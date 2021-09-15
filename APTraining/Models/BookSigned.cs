using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class BookSigned
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateSigned { get; set; }
    }
}
