using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class BookFileVisit
    {
        public int Id { get; set; }
        public int BookFileId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateVisited { get; set; }
    }
}
