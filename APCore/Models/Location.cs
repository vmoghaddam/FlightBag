using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class Location
    {
        public Location()
        {
            EmployeeLocations = new HashSet<EmployeeLocation>();
            InverseParent = new HashSet<Location>();
            InverseRootLocationNavigation = new HashSet<Location>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string FullCode { get; set; }
        public int CustomerId { get; set; }
        public string Remark { get; set; }
        public int TypeId { get; set; }
        public bool IsVirtual { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public int? ParentId { get; set; }
        public int? CityId { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Website { get; set; }
        public int? RootLocation { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Parent { get; set; }
        public virtual Location RootLocationNavigation { get; set; }
        public virtual ICollection<EmployeeLocation> EmployeeLocations { get; set; }
        public virtual ICollection<Location> InverseParent { get; set; }
        public virtual ICollection<Location> InverseRootLocationNavigation { get; set; }
    }
}
