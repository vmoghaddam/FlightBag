using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class Option
    {
        public Option()
        {
            Customers = new HashSet<Customer>();
            PersonCaoIntervalCalanderTypes = new HashSet<Person>();
            PersonMarriages = new HashSet<Person>();
            PersonNDTIntervalCalanderTypes = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public bool IsSystem { get; set; }
        public int OrderIndex { get; set; }
        public int? CreatorId { get; set; }
        public string Prop1 { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Person> PersonCaoIntervalCalanderTypes { get; set; }
        public virtual ICollection<Person> PersonMarriages { get; set; }
        public virtual ICollection<Person> PersonNDTIntervalCalanderTypes { get; set; }
    }
}
