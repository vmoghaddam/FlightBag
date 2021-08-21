using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewLocation
    {
        public string Parent { get; set; }
        public string ParentCode { get; set; }
        public string Root { get; set; }
        public string RootCode { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleFormated { get; set; }
        public string Code { get; set; }
        public string FullCode { get; set; }
        public int CustomerId { get; set; }
        public int TypeId { get; set; }
        public string Remark { get; set; }
        public bool IsVirtual { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public int? ParentId { get; set; }
        public int? CityId { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Website { get; set; }
        public int? RootLocation { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public string SortName { get; set; }
        public string Type { get; set; }
        public int? Items { get; set; }
        public int HasItems { get; set; }
        public int? Employees { get; set; }
    }
}
