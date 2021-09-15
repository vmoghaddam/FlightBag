using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class HelperBoxCrew
    {
        public int Id { get; set; }
        public int BoxId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? Date { get; set; }
    }
}
