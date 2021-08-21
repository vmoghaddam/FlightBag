using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewOrganization
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public string LogoUrl { get; set; }
        public int? TypeId { get; set; }
        public int CountryId { get; set; }
        public string Type { get; set; }
        public string SortName { get; set; }
        public string Country { get; set; }
        public int? Books { get; set; }
    }
}
