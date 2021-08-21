using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class SumEmployeeDateAlert
    {
        public int Id { get; set; }
        public int? PassportExpired { get; set; }
        public int? PassportExpiring { get; set; }
        public int? NDTExpired { get; set; }
        public int? NDTExpiring { get; set; }
        public int? CAOExpired { get; set; }
        public int? CAOExpiring { get; set; }
        public int? MedicalExpired { get; set; }
        public int? MedicalExpiring { get; set; }
    }
}
