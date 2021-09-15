using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class ViewPersonCaoLicense
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? CaoBasicTypeId { get; set; }
        public int? CaoCategoryId { get; set; }
        public int? CaoBasicId { get; set; }
        public DateTime? DateLicense { get; set; }
        public string Remark { get; set; }
        public string Result { get; set; }
        public bool? IsNew { get; set; }
        public bool? Quarantine { get; set; }
    }
}
