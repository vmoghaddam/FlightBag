using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class HelperCourse
    {
        public int Id { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? StatusId { get; set; }
    }
}
