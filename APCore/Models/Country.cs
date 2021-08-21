using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class Country
    {
        public Country()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string SortName { get; set; }
        public string Name { get; set; }
        public int? PhoneCode { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
