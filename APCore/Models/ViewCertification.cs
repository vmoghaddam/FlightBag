using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewCertification
    {
        public int Id { get; set; }
        public int? TypeId { get; set; }
        public string TypeTitle { get; set; }
        public string Description { get; set; }
        public DateTime? DateIssue { get; set; }
        public DateTime? DateExpire { get; set; }
        public DateTime? DateIRValid { get; set; }
        public int? AcTypeId { get; set; }
        public string AcType { get; set; }
        public string Rating { get; set; }
        public int? Class { get; set; }
        public string Limitation { get; set; }
        public string EmployedBy { get; set; }
        public int? EmployedById { get; set; }
        public string Occupation { get; set; }
        public int? Level { get; set; }
        public int? EmployeeId { get; set; }
        public int? PersonId { get; set; }
        public bool AirPocket { get; set; }
        public string Title { get; set; }
        public string No { get; set; }
        public int? Remain { get; set; }
        public int Expiring { get; set; }
    }
}
