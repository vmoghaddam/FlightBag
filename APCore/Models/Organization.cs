using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class Organization
    {
        public Organization()
        {
            Ac_MSNs = new HashSet<Ac_MSN>();
            AircraftTypes = new HashSet<AircraftType>();
            Books = new HashSet<Book>();
            FlightInformations = new HashSet<FlightInformation>();
            FlightPlanItems = new HashSet<FlightPlanItem>();
            Ratings = new HashSet<Rating>();
        }

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

        public virtual ICollection<Ac_MSN> Ac_MSNs { get; set; }
        public virtual ICollection<AircraftType> AircraftTypes { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<FlightInformation> FlightInformations { get; set; }
        public virtual ICollection<FlightPlanItem> FlightPlanItems { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
