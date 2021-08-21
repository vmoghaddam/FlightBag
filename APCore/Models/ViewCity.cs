using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewCity
    {
        public int Id { get; set; }
        public string City { get; set; }
        public int? StateId { get; set; }
        public string State { get; set; }
        public int CountryId { get; set; }
        public string SortName { get; set; }
        public string Country { get; set; }
        public int? PhoneCode { get; set; }
        public string FullName { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
